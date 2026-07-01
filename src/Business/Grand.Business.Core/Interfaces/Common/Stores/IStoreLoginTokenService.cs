#nullable enable

using Grand.Domain.Stores;

namespace Grand.Business.Core.Interfaces.Common.Stores;

/// <summary>
///     Store service interface
/// </summary>
public interface IStoreLoginTokenService
{
    /// <summary>
    ///     Gets a StoreLoginToken
    /// </summary>
    /// <param name="storeId">StoreId</param>
    /// <param name="token">Token</param>
    /// <returns>StoreLoginToken</returns>
    Task<StoreLoginToken> GetByToken(string storeId, string token);
    
    /// <summary>
    ///     Insert a StoreLoginToken
    /// </summary>
    /// <param name="storeLoginToken">StoreLoginToken</param>
    Task InsertAsync(StoreLoginToken storeLoginToken);
}