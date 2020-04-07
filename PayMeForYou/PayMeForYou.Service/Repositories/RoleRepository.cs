using MySql.Data.MySqlClient;
using PayMeForYou.Entity.Entities;
using PayMeForYou.Entity.RepositoryModules;
using PayMeForYou.Helper.Database.Interface;
using PayMeForYou.Service.Repositories.Interface;
using PayMeForYou.Utility.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayMeForYou.Service.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DBHelperBase _dbHelper;
        public RoleRepository(DBHelperBase dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public async Task CreateRoleAsync(Role role)
        {
            await Task.Run(() => throw new System.NotImplementedException());
        }
        public async Task UpdateRoleAsync(Role role)
        {
            await Task.Run(() => throw new System.NotImplementedException());
        }
        public async Task<Role> GetRoleAsync(int roleId)
        {
            var parameters = new List<MySqlParameter>
            {
                new MySqlParameter { ParameterName = "id", DbType = DbType.Int32, Value = roleId, Direction = ParameterDirection.Input }
            };
            var roles = await GetRolesAsync(parameters.ToArray());

            return roles.FirstOrDefault();
        }
        public async Task<List<Role>> GetRolesAsync() => await GetRolesAsync(null);
        private Role RoleMapping(IDataReader reader)
        {
            return new Role
            {
                Id = int.Parse(reader["id"].ToString()),
                RoleName = reader["role_name"].ToString(),
                Description = reader["description"].ToString(),
                Permissions = reader["permissions"].ToString(),
                CreatedBy = reader["created_by"].ToString(),
                CreatedTime = DateTime.TryParse(reader["created_time"]?.ToString(), out DateTime utcCT) ? DateTime.SpecifyKind(utcCT, DateTimeKind.Utc).ToLocalTime() : DateTime.Now,
                UpdatedBy = reader["updated_by"].ToString(),
                UpdatedTime = DateTime.TryParse(reader["updated_time"]?.ToString(), out DateTime utcUT) ? DateTime.SpecifyKind(utcUT, DateTimeKind.Utc).ToLocalTime() : DateTime.Now,
            };
        }
        private async Task<List<Role>> GetRolesAsync(IDbDataParameter[] parameters = null)
        {
            var sbCmdText = new StringBuilder("SELECT id, role_name, `description`, permissions, created_by, created_time, updated_by, updated_time FROM role");
            if (parameters != null)
                for (int i = 0; i < parameters.Length; i++)
                    sbCmdText.AppendFormat(" {0} {1} = @{1} ", i == 0 ? "WHERE" : "AND", parameters[i].ParameterName);
            sbCmdText.Append(";");
            var cmdText = MySqlDBUtility.GetSelectNoLockCmdText(sbCmdText.ToString());

            var result = new List<Role>();
            void handler(IDataReader reader) => result.Add(RoleMapping(reader));
            var handlerSetting = new List<DBReaderHandler>
            {
                new DBReaderHandler { IsFirstResult = true, Handler = handler }
            };
            await _dbHelper.ExecuteReaderAsync(cmdText, handlerSetting, parameters: parameters);

            return result;
        }
    }
}
