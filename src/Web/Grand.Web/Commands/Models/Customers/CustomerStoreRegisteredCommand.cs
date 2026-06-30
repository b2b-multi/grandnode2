using Grand.Domain.Common;
using Grand.Domain.Customers;
using Grand.Web.Models.Customer;
using MediatR;

namespace Grand.Web.Commands.Models.Customers;

public class CustomerStoreRegisteredCommand : IRequest<bool>
{
    public Customer Customer { get; set; }
    public Domain.Stores.Store Store { get; set; }
    public RegisterStoreModel Model { get; set; }
}