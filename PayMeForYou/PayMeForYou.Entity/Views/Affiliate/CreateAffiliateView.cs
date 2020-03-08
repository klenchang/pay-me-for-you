namespace PayMeForYou.Entity.Views.Affiliate
{
    public class CreateAffiliateView
    {
        public string AffiliateName { get; set; }
        public string CompanyName { get; set; }
        public decimal FundInCommissionRate { get; set; }
        public decimal FundOutCommissionRate { get; set; }
        public string CreatedBy { get; set; }
    }
}
