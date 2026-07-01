using Grand.Business.Core.Interfaces.Common.Stores;
using Grand.Data;
using Grand.Domain.Stores;
using MongoDB.Driver.Linq;

namespace Grand.Business.Common.Services.Stores;

public class StoreLoginTokenService(IRepository<StoreLoginToken> storeLoginTokenRepository) : IStoreLoginTokenService
{
    public async Task<StoreLoginToken> GetByToken(string storeId, string token)
    {
        return await storeLoginTokenRepository.Table
            .Where(x => x.StoreId == storeId && x.Token == token && x.CreatedOnUtc >= DateTime.UtcNow.AddSeconds(-5))
            .FirstOrDefaultAsync();
    }

    public async Task InsertAsync(StoreLoginToken storeLoginToken)
    {
        await storeLoginTokenRepository.InsertAsync(storeLoginToken);
    }
}