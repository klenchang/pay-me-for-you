using PayMeForYou.Entity.Enums;
using PayMeForYou.Entity.RepositoryModules;
using System.Collections.Generic;

namespace PayMeForYou.Service.Repositories.Interface
{
    internal interface IMerchantRepository
    {
        public List<Merchant> GetMerchants(string merchantName, SettlementMethod settlementMethod, bool status);
        public void CreateMerchant(Merchant merchant);
        public void UpdateMerchant(Merchant merchant);
        public Merchant GetMerchant(int merchantId);
    }
}
