using PayMeForYou.Api.Service.Library.Services.Interface;
using PayMeForYou.Entity.Enums;
using PayMeForYou.Entity.Views.Merchant;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Api.Service.Library.Services
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
