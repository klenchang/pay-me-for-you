using System;
using System.Data;

namespace PayMeForYou.Helper.Database.Interface
{
    public abstract class DBHelperBase : IDisposable
    {
        private readonly IDbConnection _connection;

        public DBHelperBase(IDbConnection connection)
        {
            _connection = connection;
        }
        public void Dispose() => _connection.Dispose();
    }
}
