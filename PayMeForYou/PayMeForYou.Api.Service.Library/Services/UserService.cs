using PayMeForYou.Api.Service.Library.Repositories.Interface;
using PayMeForYou.Api.Service.Library.Services.Interface;
using PayMeForYou.Entity.RepositoryModules;
using PayMeForYou.Entity.Views.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Api.Service.Library.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }
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
            var users = await _repository.GetUsersAsync(userName, merchantId);
            var list = new List<UserView>();
            for (int i = 1; i <= users.Count; i++)
                list.Add(ConvertToView(users[i - 1], i));

            return list;
        }

        public async Task ResetPasswordAsync(string userId, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateUserAsync(UpdateUserView userView)
        {
            throw new System.NotImplementedException();
        }

        private UserView ConvertToView(User user, int rowNo)
        {
            return new UserView
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastLoginFrom = user.LastLoginFrom,
                LastLoginTime = user.LastLoginTime,
                LastName = user.LastName,
                MerchantName = user.MerchantName,
                UserName = user.UserName,
                Status = user.Status,
                RowNo = rowNo
            };
        }
    }
}
