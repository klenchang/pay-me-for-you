using PayMeForYou.Entity.Enums;

namespace PayMeForYou.Entity.Views.Merchant
{
    public class MerchantView
    {
        public int RowNo { get; set; }
        public int Id { get; set; }
        public string MerchantName { get; set; }
        public string CompanyName { get; set; }
        public Currency Currency { get; set; }
        public decimal Balance { get; set; }
        public SettlementMethod SettlementMethod { get; set; }
        public decimal FundOutCommissionRate { get; set; }
        public decimal FundInCommissionRate { get; set; }
        public bool Status { get; set; }
    }
}
