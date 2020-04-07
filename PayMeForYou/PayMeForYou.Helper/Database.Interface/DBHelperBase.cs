using PayMeForYou.Entity.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace PayMeForYou.Helper.Database.Interface
{
    public abstract class DBHelperBase
    {
        protected abstract DbConnection GetConnection();
        public async Task ExecuteReaderAsync(string cmdText, IEnumerable<DBReaderHandler> readerHandlers, IDbDataParameter[] parameters = null, CommandType cmdType = CommandType.Text)
        {
            using var conn = GetConnection();
            using var cmd = GetCommand(conn, cmdText, parameters, cmdType);
            using var reader = await cmd.ExecuteReaderAsync();
            foreach (var handler in readerHandlers)
            {
                if (handler.IsFirstResult || (!handler.IsFirstResult && await reader.NextResultAsync()))
                    while (await reader.ReadAsync())
                        handler.Handler.Invoke(reader);
            }
        }
        public async Task<int> ExecuteNonQueryAsync(string cmdText, IDbDataParameter[] parameters = null, CommandType cmdType = CommandType.Text)
        {
            using var conn = GetConnection();
            return await GetCommand(conn, cmdText, parameters, cmdType).ExecuteNonQueryAsync();
        }
        public async Task<object> ExecuteScalarAsync(string cmdText, IDbDataParameter[] parameters = null, CommandType cmdType = CommandType.Text)
        { 
            using var conn = GetConnection();
            return await GetCommand(conn, cmdText, parameters, cmdType).ExecuteScalarAsync();
        }
        private DbCommand GetCommand(DbConnection conn, string cmdText, IDbDataParameter[] parameters = null, CommandType cmdType = CommandType.Text)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            return cmd;
        }
    }
}
