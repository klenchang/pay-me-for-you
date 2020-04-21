using PayMeForYou.Entity.Views.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Api.Service.Library.Services.Interface
{
    public interface IUserService
    {
        public Task<List<UserView>> GetUsersAsync(string userName, int merchantId);
        public Task ResetPasswordAsync(string userId, string password);
        public Task CreateUserAsync(CreateUserView userView);
        public Task UpdateUserAsync(UpdateUserView userView);
        public Task<UserView> GetUserAsync(int userId);
    }
}
