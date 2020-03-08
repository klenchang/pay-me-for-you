using PayMeForYou.Entity.Enums;
using PayMeForYou.Entity.Views.Merchant;
using System.Collections.Generic;

namespace PayMeForYou.Service.Services.Interface
{
    public interface IMerchantService
    {
        public List<MerchantView> GetMerchants(string merchantName, SettlementMethod settlementMethod, bool status);
        public void CreateMerchant(CreateMerchantView merchant);
        public void UpdateMerchant(UpdateMerchantView merchant);
        public MerchantView GetMerchant(int merchantId);
    }
}
