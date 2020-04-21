using PayMeForYou.Entity.Enums;
using PayMeForYou.Entity.Views.Merchant;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Api.Service.Library.Services.Interface
{
    public interface IMerchantService
    {
        public Task<List<MerchantView>> GetMerchantsAsync(string merchantName, SettlementMethod settlementMethod, bool status);
        public Task CreateMerchantAsync(CreateMerchantView merchantView);
        public Task UpdateMerchantAsync(UpdateMerchantView merchantView);
        public Task<MerchantView> GetMerchantAsync(int merchantId);
    }
}
