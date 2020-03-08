using PayMeForYou.Entity.Enums;
using PayMeForYou.Entity.RepositoryModules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Service.Repositories.Interface
{
    public interface IMerchantRepository
    {
        public Task<List<Merchant>> GetMerchantsAsync(string merchantName, SettlementMethod settlementMethod, bool status);
        public Task CreateMerchantAsync(Merchant merchant);
        public Task UpdateMerchantAsync(Merchant merchant);
        public Task<Merchant> GetMerchantAsync(int merchantId);
    }
}
