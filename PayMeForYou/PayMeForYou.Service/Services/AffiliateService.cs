using PayMeForYou.Entity.Views.Affiliate;
using PayMeForYou.Service.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Service.Services
{
    public class AffiliateService : IAffiliateService
    {
        public async Task CreateAffiliateAsync(CreateAffiliateView affiliateView)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AffiliateView> GetAffiliateAsync(int affiliateId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<AffiliateView>> GetAffiliatesAsync(string affiliateName, bool status)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAffiliateAsync(UpdateAffiliateView affiliateView)
        {
            throw new System.NotImplementedException();
        }
    }
}
