using Grand.Domain.Customers;

namespace Grand.Domain.Stores;

/// <summary>
///     Represents a storeLoginToken
/// </summary>
public class StoreLoginToken : BaseEntity
{
    /// <summary>
    ///     Gets or sets the store name
    /// </summary>
    public string StoreId { get; set; }

    /// <summary>
    ///     Gets a token
    /// </summary>
    public string Token {
        get;
        set => field = string.IsNullOrEmpty(value) ? UniqueIdentifier.New : value;
    } = UniqueIdentifier.New;

    /// <summary>
    ///     Target Customer
    /// </summary>
    public Customer TargetCustomer { get; set; }
}