using PayMeForYou.Entity.Enums;
using PayMeForYou.Entity.RepositoryModules;
using PayMeForYou.Service.Repositories.Interface;
using System.Collections.Generic;

namespace PayMeForYou.Service.Repositories
{
    internal class MerchantRepository : IMerchantRepository
    {
        public void CreateMerchant(Merchant merchant)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateMerchant(Merchant merchant)
        {
            throw new System.NotImplementedException();
        }

        public Merchant GetMerchant(int merchantId)
        {
            throw new System.NotImplementedException();
        }

        public List<Merchant> GetMerchants(string merchantName, SettlementMethod settlementMethod, bool status)
        {
            throw new System.NotImplementedException();
        }
    }
}
