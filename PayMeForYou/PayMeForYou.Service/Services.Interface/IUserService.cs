using PayMeForYou.Entity.Views.User;
using System.Collections.Generic;

namespace PayMeForYou.Service.Services.Interface
{
    public interface IUserService
    {
        public List<UserView> GetUsers(string userName, int merchantId);
        public void ResetPassword(string userId, string password);
        public void CreateUser(CreateUserView user);
        public void UpdateUser(UpdateUserView user);
        public UserView GetUser(int userId);
    }
}
