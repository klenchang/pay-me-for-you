using PayMeForYou.Entity.RepositoryModules;
using System.Collections.Generic;

namespace PayMeForYou.Service.Repositories.Interface
{
    internal interface IRoleRepository
    {
        public List<Role> GetRoles();
        public void CreateRole(Role role);
        public void UpdateRole(Role role);
        public Role GetRole(int roleId);
    }
}
