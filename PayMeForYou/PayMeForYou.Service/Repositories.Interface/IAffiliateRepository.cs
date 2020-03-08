using PayMeForYou.Entity.RepositoryModules;
using System.Collections.Generic;

namespace PayMeForYou.Service.Repositories.Interface
{
    internal interface IAffiliateRepository
    {
        public List<Affiliate> GetAffiliates(string affiliateName, bool status);
        public void CreateAffiliate(Affiliate affiliate);
        public void UpdateAffiliate(Affiliate affiliate);
        public Affiliate GetAffiliate(int affiliateId);
    }
}
