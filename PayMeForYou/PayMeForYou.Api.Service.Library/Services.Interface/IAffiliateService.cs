using PayMeForYou.Entity.Views.Affiliate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Api.Service.Library.Services.Interface
{
    public interface IAffiliateService
    {
        public Task<List<AffiliateView>> GetAffiliatesAsync(string affiliateName, bool status);
        public Task CreateAffiliateAsync(CreateAffiliateView affiliateView);
        public Task UpdateAffiliateAsync(UpdateAffiliateView affiliateView);
        public Task<AffiliateView> GetAffiliateAsync(int affiliateId);
    }
}
