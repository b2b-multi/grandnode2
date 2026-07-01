using Grand.Infrastructure.ModelBinding;
using Grand.Infrastructure.Models;
using Grand.SharedKernel;
using System.ComponentModel.DataAnnotations;

namespace Grand.Web.Models.Customer;

public class LoginStoreModel : BaseModel
{
    [MaxLength(FieldSizeLimits.EmailMaxLength)]
    [DataType(DataType.EmailAddress)]
    [GrandResourceDisplayName("Account.Login.Fields.Email")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [GrandResourceDisplayName("Account.Login.Fields.Password")]
    public string Password { get; set; }
}