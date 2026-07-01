using FluentValidation;
using Grand.Business.Core.Interfaces.Common.Directory;
using Grand.Business.Core.Interfaces.Common.Localization;
using Grand.Business.Core.Interfaces.Customers;
using Grand.Domain.Common;
using Grand.Domain.Customers;
using Grand.Infrastructure;
using Grand.Infrastructure.Models;
using Grand.Infrastructure.Validators;
using Grand.SharedKernel.Captcha;
using Grand.SharedKernel.Extensions;
using Grand.Web.Common.Validators;
using Grand.Web.Features.Models.Customers;
using Grand.Web.Models.Customer;
using MediatR;

namespace Grand.Web.Validators.Customer;

public class RegisterStoreValidator : BaseGrandValidator<RegisterStoreModel>
{
    public RegisterStoreValidator(
        IEnumerable<IValidatorConsumer<RegisterStoreModel>> validators,
        IEnumerable<IValidatorConsumer<ICaptchaValidModel>> validatorsCaptcha,
        ITranslationService translationService,
        CustomerSettings customerSettings, CaptchaSettings captchaSettings,
        IHttpContextAccessor httpcontextAccessor, IGoogleReCaptchaValidator googleReCaptchaValidator,
        IMediator mediator, ICustomerAttributeParser customerAttributeParser,
        ICustomerService customerService,
        IGroupService groupService, IContextAccessor contextAccessor
    )
        : base(validators)
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage(translationService.GetResource("Account.Fields.Email.Required"));
        RuleFor(x => x.Email).EmailAddress().WithMessage(translationService.GetResource("Common.WrongEmail"));

        RuleFor(x => x.Password).NotEmpty()
            .WithMessage(translationService.GetResource("Account.Fields.Password.Required"));

        if (!string.IsNullOrEmpty(customerSettings.PasswordRegularExpression))
            RuleFor(x => x.Password).Matches(customerSettings.PasswordRegularExpression)
                .WithMessage(string.Format(translationService.GetResource("Account.Fields.Password.Validation")));

        RuleFor(x => x.ConfirmPassword).NotEmpty()
            .WithMessage(translationService.GetResource("Account.Fields.ConfirmPassword.Required"));
        RuleFor(x => x.ConfirmPassword).Equal(x => x.Password)
            .WithMessage(translationService.GetResource("Account.Fields.Password.EnteredPasswordsDoNotMatch"));

        // if (customerSettings.PhoneRequired && customerSettings.PhoneEnabled)
        //     RuleFor(x => x.Phone).NotEmpty()
        //         .WithMessage(translationService.GetResource("Account.Fields.Phone.Required"));
       
        // if (captchaSettings.Enabled && captchaSettings.ShowOnRegistrationPage)
        // {
        //     RuleFor(x => x.Captcha).NotNull().WithMessage(translationService.GetResource("Account.Captcha.Required"));
        //     RuleFor(x => x.Captcha)
        //         .SetValidator(new CaptchaValidator(validatorsCaptcha, httpcontextAccessor, googleReCaptchaValidator));
        // }

        RuleFor(x => x).CustomAsync(async (x, context, _) =>
        {
            // var customerAttributes = await mediator.Send(new GetParseCustomAttributes { SelectedAttributes = x.SelectedAttributes }, _);
            // var customerAttributeWarnings = await customerAttributeParser.GetAttributeWarnings(customerAttributes);
            // foreach (var error in customerAttributeWarnings) context.AddFailure(error);
            //
            // if (await groupService.IsRegistered(contextAccessor.WorkContext.CurrentCustomer))
            // {
            //     context.AddFailure("Current customer is already registered");
            //     return;
            // }


            //validate unique user
            if (await customerService.GetStoreAccountByEmail(x.Email) != null)
            {
                context.AddFailure(translationService.GetResource("Account.Register.Errors.EmailAlreadyExists"));
            }
        });
    }
}