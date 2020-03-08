using PayMeForYou.Entity.Views.Affiliate;
using System.Collections.Generic;

namespace PayMeForYou.Service.Services.Interface
{
    public interface IAffiliateService
    {
        public List<AffiliateView> GetAffiliates(string affiliateName, bool status);
        public void CreateAffiliate(CreateAffiliateView affiliate);
        public void EditAffiliate(EditAffiliateView affiliate);
        public AffiliateView GetAffiliate(int affiliateId);
    }
}
