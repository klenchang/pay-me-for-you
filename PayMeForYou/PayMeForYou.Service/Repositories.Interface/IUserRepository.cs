using PayMeForYou.Entity.RepositoryModules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Service.Repositories.Interface
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUsersAsync(string userName, int merchantId);
        public Task ResetPasswordAsync(string userId, string password);
        public Task CreateUserAsync(User user);
        public Task UpdateUserAsync(User user);
        public Task<User> GetUserAsync(int userId);
    }
}
