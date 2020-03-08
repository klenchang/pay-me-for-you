using PayMeForYou.Entity.Views.User;
using PayMeForYou.Service.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Service.Services
{
    public class UserService : IUserService
    {
        public async Task CreateUserAsync(CreateUserView userView)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserView> GetUserAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<UserView>> GetUsersAsync(string userName, int merchantId)
        {
            throw new System.NotImplementedException();
        }

        public async Task ResetPasswordAsync(string userId, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateUserAsync(UpdateUserView userView)
        {
            throw new System.NotImplementedException();
        }
    }
}
