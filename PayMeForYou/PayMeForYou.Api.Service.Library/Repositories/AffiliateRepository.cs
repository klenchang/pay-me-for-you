using PayMeForYou.Api.Service.Library.Repositories.Interface;
using PayMeForYou.Entity.RepositoryModules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Api.Service.Library.Repositories
{
    internal class AffiliateRepository : IAffiliateRepository
    {
        public async Task CreateAffiliateAsync(Affiliate affiliate)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Affiliate> GetAffiliateAsync(int affiliateId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Affiliate>> GetAffiliatesAsync(string affiliateName, bool status)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAffiliateAsync(Affiliate affiliate)
        {
            throw new System.NotImplementedException();
        }
    }
}
