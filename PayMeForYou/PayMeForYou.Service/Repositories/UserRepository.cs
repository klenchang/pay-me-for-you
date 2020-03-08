using PayMeForYou.Entity.RepositoryModules;
using PayMeForYou.Service.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Service.Repositories
{
    internal class UserRepository : IUserRepository
    {
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
            throw new System.NotImplementedException();
        }

        public async Task ResetPasswordAsync(string userId, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
