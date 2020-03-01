using PayMeForYou.Entity.Enums;
using System;

namespace PayMeForYou.Entity.RepositoryModules
{
    public class Merchant
    {
        public int Id { get; set; }
        public string MerchantName { get; set; }
        public string CompanyName { get; set; }
        public int AffiliateId { get; set; }
        public SettlementMethod SettlementMethod { get; set; }
        public decimal FundInCommissionRate { get; set; }
        public decimal FundInMinAmount { get; set; }
        public decimal FundInMaxAmount { get; set; }
        public decimal FundOutCommissionRate { get; set; }
        public decimal FundOutMinAmount { get; set; }
        public decimal FundOutMaxAmount { get; set; }
        public Currency Currency { get; set; }
        public decimal Balance { get; set; }
        public bool Status { get; set; }
        public bool OpenBankFundInAPI { get; set; }
        public bool OpenBankFundOutAPI { get; set; }
        public string MerchantCode { get; set; }
        public string SecretKey { get; set; }
        public string NotificationUrl { get; set; }
        public string IPWhiteList { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
