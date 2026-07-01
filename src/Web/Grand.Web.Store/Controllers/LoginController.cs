using Grand.Business.Core.Interfaces.Authentication;
using Grand.Business.Core.Interfaces.Common.Localization;
using Grand.Business.Core.Interfaces.Common.Stores;
using Grand.Business.Core.Interfaces.Customers;
using Grand.Business.Core.Interfaces.Messages;
using Grand.Domain.Common;
using Grand.Domain.Customers;
using Grand.Infrastructure;
using Grand.Web.AdminShared.Controllers;
using Grand.Web.Store.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Grand.Web.Store.Controllers;

[Area(Constants.AreaStore)]
public class LoginController : BaseLoginController
{
    #region props
    private readonly IStoreLoginTokenService _storeLoginTokenService;
    private IContextAccessor _contextAccessor;
    #endregion

    #region  ctors
    public LoginController(CustomerSettings customerSettings, CaptchaSettings captchaSettings,
        ITranslationService translationService, ICustomerManagerService customerManagerService,
        ICustomerService customerService, IGrandAuthenticationService authenticationService,
        IMessageProviderService messageProviderService, IContextAccessor contextAccessor, IStoreLoginTokenService storeLoginTokenService, IMediator mediator) : base(
        customerSettings, captchaSettings, translationService, customerManagerService, customerService,
        authenticationService, messageProviderService, contextAccessor, mediator)
    {
        _storeLoginTokenService = storeLoginTokenService;
        _contextAccessor = contextAccessor;
    }
    #endregion
    
    public async Task<IActionResult> ByToken([FromQuery]string token)
    {
        var storeId = _contextAccessor.StoreContext.CurrentStore.Id;
        if (string.IsNullOrEmpty(storeId))
        {
            return NotFound();
        }
        var storeLoginToken = await _storeLoginTokenService.GetByToken(storeId, token);
        if (storeLoginToken != null)
        {
            await SignInAction(storeLoginToken.TargetCustomer, true);
            return RedirectToAction("Index", "Home", new { Area = Constants.AreaStore });    
        }
        
        return NotFound();
    }
}