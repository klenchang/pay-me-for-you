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
            using var cmd = conn.CreateCommand();
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            using var reader = await cmd.ExecuteReaderAsync();
            foreach (var handler in readerHandlers)
            {
                if (handler.IsFirstResult || (!handler.IsFirstResult && await reader.NextResultAsync()))
                    while (await reader.ReadAsync())
                        handler.Handler.Invoke(reader);
            }
        }
    }
}
