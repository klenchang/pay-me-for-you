using PayMeForYou.Entity.Enums;

namespace PayMeForYou.Entity.Views.Merchant
{
    public class EditMerchantView
    {
        public int Id { get; set; }
        public string MerchantName { get; set; }
        public decimal Balance { get; set; }
        public string CompanyName { get; set; }
        public SettlementMethod SettlementMethod { get; set; }
        public decimal FundOutCommissionRate { get; set; }
        public decimal FundOutMinAmount { get; set; }
        public decimal FundOutMaxAmount { get; set; }
        public decimal FundInCommissionRate { get; set; }
        public decimal FundInMinAmount { get; set; }
        public decimal FundInMaxAmount { get; set; }
        public bool Status { get; set; }
        public string UpdatedBy { get; set; }
    }
}
