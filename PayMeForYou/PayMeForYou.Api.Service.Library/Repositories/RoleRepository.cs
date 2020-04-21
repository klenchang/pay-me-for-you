using MySql.Data.MySqlClient;
using PayMeForYou.Api.Service.Library.Repositories.Interface;
using PayMeForYou.Entity.Entities;
using PayMeForYou.Entity.RepositoryModules;
using PayMeForYou.Helper.Database.Interface;
using PayMeForYou.Utility.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayMeForYou.Api.Service.Library.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DBHelperBase _dbHelper;
        public RoleRepository(DBHelperBase dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public async Task<int> CreateRoleAsync(Role role)
        {
            string cmdText = @"INSERT INTO role (role_name, `description`, permissions, created_by, created_time, updated_by, updated_time)
                               VALUES (@role_name, @description, @permissions, @created_by, @created_time, null, null);
                               SELECT LAST_INSERT_ID();";
            
            var parameters = new List<MySqlParameter> 
            { 
                new MySqlParameter("role_name", MySqlDbType.VarChar) { Value = role.RoleName, Direction = ParameterDirection.Input },
                new MySqlParameter("description", MySqlDbType.VarChar) { Value = role.Description, Direction = ParameterDirection.Input },
                new MySqlParameter("permissions", MySqlDbType.VarChar) { Value = role.Permissions, Direction = ParameterDirection.Input },
                new MySqlParameter("created_by", MySqlDbType.VarChar) { Value = role.CreatedBy, Direction = ParameterDirection.Input },
                new MySqlParameter("created_time", MySqlDbType.Timestamp) { Value = role.CreatedTime, Direction = ParameterDirection.Input }
            };
            return Convert.ToInt32(await _dbHelper.ExecuteScalarAsync(cmdText, parameters: parameters.ToArray()));
        }
        public async Task<int> UpdateRoleAsync(Role role)
        {
            string cmdText = @"UPDATE role 
                               SET `description` = @description, 
                                    role_name = @role_name, 
                                    permissions = @permissions, 
                                    updated_by = @updated_by, 
                                    updated_time = @updated_time
                               WHERE id = @id;";

            var parameters = new List<MySqlParameter>
            {
                new MySqlParameter("id", MySqlDbType.Int32) { Value = role.Id, Direction = ParameterDirection.Input },
                new MySqlParameter("role_name", MySqlDbType.VarChar) { Value = role.RoleName, Direction = ParameterDirection.Input },
                new MySqlParameter("description", MySqlDbType.VarChar) { Value = role.Description, Direction = ParameterDirection.Input },
                new MySqlParameter("permissions", MySqlDbType.VarChar) { Value = role.Permissions, Direction = ParameterDirection.Input },
                new MySqlParameter("updated_by", MySqlDbType.VarChar) { Value = role.UpdatedBy, Direction = ParameterDirection.Input },
                new MySqlParameter("updated_time", MySqlDbType.Timestamp) { Value = role.UpdatedTime, Direction = ParameterDirection.Input }
            };
            return await _dbHelper.ExecuteNonQueryAsync(cmdText, parameters: parameters.ToArray());
        }
        public async Task<Role> GetRoleAsync(int roleId)
        {
            var parameters = new List<MySqlParameter>
            {
                new MySqlParameter("id", MySqlDbType.Int32) { Value = roleId, Direction = ParameterDirection.Input }
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
