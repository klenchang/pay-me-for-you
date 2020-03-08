using PayMeForYou.Entity.Enums;

namespace PayMeForYou.Entity.Views.Affiliate
{
    public class AffiliateView
    {
        public int RowNo { get; set; }
        public int Id { get; set; }
        public string AffiliateName { get; set; }
        public string CompanyName { get; set; }
        public Currency Currency { get; set; }
        public decimal Balance { get; set; }
        public decimal FundInCommissionRate { get; set; }
        public decimal FundOutCommissionRate { get; set; }
        public bool Status { get; set; }
    }
}
