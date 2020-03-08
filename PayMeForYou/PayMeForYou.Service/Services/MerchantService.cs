using PayMeForYou.Entity.Enums;
using PayMeForYou.Entity.Views.Merchant;
using PayMeForYou.Service.Services.Interface;
using System.Collections.Generic;

namespace PayMeForYou.Service.Services
{
    public class MerchantService : IMerchantService
    {
        public void CreateMerchant(CreateMerchantView merchant)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateMerchant(UpdateMerchantView merchant)
        {
            throw new System.NotImplementedException();
        }

        public MerchantView GetMerchant(int merchantId)
        {
            throw new System.NotImplementedException();
        }

        public List<MerchantView> GetMerchants(string merchantName, SettlementMethod settlementMethod, bool status)
        {
            throw new System.NotImplementedException();
        }
    }
}
