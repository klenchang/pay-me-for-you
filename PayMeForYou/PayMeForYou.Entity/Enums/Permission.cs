using System.ComponentModel;

namespace PayMeForYou.Entity.Enums
{
    public enum Permission
    {
        CREATE_MERCHANT,
        UPDATE_MERCHANT,
        VIEW_MERCHANT,
        VIEW_INTEGRATION,
        UPDATE_INTEGRATION,
        CREATE_USER,
        UPDATE_USER,
        VIEW_USER,
        CREATE_ROLE,
        UPDATE_ROLE,
        VIEW_ROLE,
        UPDATE_TRANSACTION,
        VIEW_FUNDOUT_TRANSACTION,
        TOP_UP,
        BALANCE_ADJUSTMENT,
        VIEW_SETTLEMENT_REPORT,
        VIEW_FUNDOUT_REPORT,
        VIEW_FUNDIN_REPORT,
        VIEW_MERCHANT_SUMMARY_REPORT,
        VIEW_FUND_STATEMENT
    }
}
