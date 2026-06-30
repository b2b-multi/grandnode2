using Grand.Infrastructure.ModelBinding;
using Grand.Infrastructure.Models;
using Grand.SharedKernel;
using System.ComponentModel.DataAnnotations;

namespace Grand.Web.Models.Customer;

public class RegisterStoreModel : BaseModel
{
    [MaxLength(FieldSizeLimits.EmailMaxLength)]
    [DataType(DataType.EmailAddress)]
    [GrandResourceDisplayName("Account.Fields.Email")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [GrandResourceDisplayName("Account.Fields.Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [GrandResourceDisplayName("Account.Fields.ConfirmPassword")]
    public string ConfirmPassword { get; set; }
}