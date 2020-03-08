using PayMeForYou.Entity.RepositoryModules;
using System.Collections.Generic;

namespace PayMeForYou.Service.Repositories.Interface
{
    internal interface IUserRepository
    {
        public List<User> GetUsers(string userName, int merchantId);
        public void ResetPassword(string userId, string password);
        public void CreateUser(User user);
        public void UpdateUser(User user);
        public User GetUser(int userId);
    }
}
