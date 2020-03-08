using PayMeForYou.Entity.Enums;
using System;

namespace PayMeForYou.Entity.RepositoryModules
{
    public class Affiliate
    {
        public int Id { get; set; }
        public string AffiliateName { get; set; }
        public string CompanyName { get; set; }
        public decimal FundInCommissionRate { get; set; }
        public decimal FundOutCommissionRate { get; set; }
        public Currency Currency { get; set; }
        public decimal Balance { get; set; }
        public bool Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
