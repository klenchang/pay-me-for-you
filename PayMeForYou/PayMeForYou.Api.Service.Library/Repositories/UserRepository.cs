using PayMeForYou.Api.Service.Library.Repositories.Interface;
using PayMeForYou.Entity.Entities;
using PayMeForYou.Entity.RepositoryModules;
using PayMeForYou.Helper.Database.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PayMeForYou.Api.Service.Library.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DBHelperBase _dbHelper;
        public UserRepository(DBHelperBase dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public async Task CreateUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> GetUserAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<User>> GetUsersAsync(string userName, int merchantId)
        {
            var result = new List<User>();
            var cmdText = @"
                SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
                SELECT id, role_name, `description`, permissions, created_by, created_time, updated_by, updated_time FROM role;
                COMMIT;";
            void handler(IDataReader reader) => result.Add(UserMapping(reader));
            var handlerSetting = new List<DBReaderHandler> { { new DBReaderHandler { IsFirstResult = true, Handler = handler } } };
            await _dbHelper.ExecuteReaderAsync(cmdText, handlerSetting);

            return result;
        }

        public async Task ResetPasswordAsync(string userId, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        private User UserMapping(IDataReader reader)
        {
            return new User
            {
                Id = int.Parse(reader["id"].ToString()),
                //RoleName = reader["role_name"].ToString(),
                //Description = reader["description"].ToString(),
                //Permissions = reader["permissions"].ToString(),
                CreatedBy = reader["created_by"].ToString(),
                CreatedTime = DateTime.TryParse(reader["created_time"]?.ToString(), out DateTime utcCT) ? DateTime.SpecifyKind(utcCT, DateTimeKind.Utc).ToLocalTime() : DateTime.Now,
                UpdatedBy = reader["updated_by"].ToString(),
                UpdatedTime = DateTime.TryParse(reader["updated_time"]?.ToString(), out DateTime utcUT) ? DateTime.SpecifyKind(utcUT, DateTimeKind.Utc).ToLocalTime() : DateTime.Now,
            };
        }
    }
}
