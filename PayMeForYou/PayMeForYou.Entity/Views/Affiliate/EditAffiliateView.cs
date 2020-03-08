namespace PayMeForYou.Entity.Views.Affiliate
{
    public class EditAffiliateView
    {
        public int Id { get; set; }
        public string AffiliateName { get; set; }
        public decimal Balance { get; set; }
        public string CompanyName { get; set; }
        public decimal FundInCommissionRate { get; set; }
        public decimal FundOutCommissionRate { get; set; }
        public bool Status { get; set; }
        public string UpdatedBy { get; set; }
    }
}
