using System.Text;

namespace PayMeForYou.Utility.Database
{
    public static class MySqlDBUtility
    {
        public static string GetSelectNoLockCmdText(string cmdText)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
            sb.AppendLine(cmdText);
            sb.AppendLine("COMMIT;");

            return sb.ToString();
        }
    }
}
