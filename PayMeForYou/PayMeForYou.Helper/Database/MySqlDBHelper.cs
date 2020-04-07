using MySql.Data.MySqlClient;
using PayMeForYou.Helper.Database.Interface;
using System.Data.Common;

namespace PayMeForYou.Helper.Database
{
    public class MySqlDBHelper : DBHelperBase
    {
        private readonly string _connectionString;
        public MySqlDBHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override DbConnection GetConnection()
        {
            var conn = new MySqlConnection(_connectionString);
            conn.Open();
            return conn;
        }
    }
}
