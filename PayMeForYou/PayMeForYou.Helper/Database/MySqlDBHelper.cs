using MySql.Data.MySqlClient;
using PayMeForYou.Helper.Database.Interface;

namespace PayMeForYou.Helper.Database
{
    public class MySqlDBHelper : DBHelperBase
    {
        public MySqlDBHelper(string connectionString) : base(new MySqlConnection(connectionString)) { }
    }
}
