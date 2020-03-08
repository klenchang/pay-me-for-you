using PayMeForYou.Entity.Enums;

namespace PayMeForYou.Entity.Views.Merchant
{
    public class CreateMerchantView
    {
        public string MerchantName { get; set; }
        public int AffiliateId { get; set; }
        public string CompanyName { get; set; }
        public SettlementMethod SettlementMethod { get; set; }
        public decimal FundInCommissionRate { get; set; }
        public decimal FundInMinAmount { get; set; }
        public decimal FundInMaxAmount { get; set; }
        public decimal FundOutCommissionRate { get; set; }
        public decimal FundOutMinAmount { get; set; }
        public decimal FundOutMaxAmount { get; set; }
        public bool OpenBankFundInAPI { get; set; }
        public bool OpenBankFundOutAPI { get; set; }
        public string CreatedBy { get; set; }
    }
}
