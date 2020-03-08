using PayMeForYou.Entity.RepositoryModules;
using PayMeForYou.Service.Repositories.Interface;
using System.Collections.Generic;

namespace PayMeForYou.Service.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public void CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public User GetUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetUsers(string userName, int merchantId)
        {
            throw new System.NotImplementedException();
        }

        public void ResetPassword(string userId, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
