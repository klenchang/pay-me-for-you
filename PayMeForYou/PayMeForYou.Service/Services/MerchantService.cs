using PayMeForYou.Entity.Enums;
using PayMeForYou.Entity.Views.Merchant;
using PayMeForYou.Service.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Service.Services
{
    public class MerchantService : IMerchantService
    {
        public async Task CreateMerchantAsync(CreateMerchantView merchantView)
        {
            throw new System.NotImplementedException();
        }

        public async Task<MerchantView> GetMerchantAsync(int merchantId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<MerchantView>> GetMerchantsAsync(string merchantName, SettlementMethod settlementMethod, bool status)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateMerchantAsync(UpdateMerchantView merchantView)
        {
            throw new System.NotImplementedException();
        }
    }
}
