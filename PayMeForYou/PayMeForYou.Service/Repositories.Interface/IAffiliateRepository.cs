using PayMeForYou.Entity.RepositoryModules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Service.Repositories.Interface
{
    public interface IAffiliateRepository
    {
        public Task<List<Affiliate>> GetAffiliatesAsync(string affiliateName, bool status);
        public Task CreateAffiliateAsync(Affiliate affiliate);
        public Task UpdateAffiliateAsync(Affiliate affiliate);
        public Task<Affiliate> GetAffiliateAsync(int affiliateId);
    }
}
