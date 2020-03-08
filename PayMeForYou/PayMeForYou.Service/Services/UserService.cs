using PayMeForYou.Entity.Views.User;
using PayMeForYou.Service.Services.Interface;
using System.Collections.Generic;

namespace PayMeForYou.Service.Services
{
    public class UserService : IUserService
    {
        public void CreateUser(CreateUserView user)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(UpdateUserView user)
        {
            throw new System.NotImplementedException();
        }

        public UserView GetUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public List<UserView> GetUsers(string userName, int merchantId)
        {
            throw new System.NotImplementedException();
        }

        public void ResetPassword(string userId, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
