using PayMeForYou.Entity.Views.Role;
using System.Collections.Generic;

namespace PayMeForYou.Service.Services.Interface
{
    public interface IRoleService
    {
        public List<RoleView> GetRoles();
        public void CreateRole(CreateRoleView role);
        public void UpdateRole(UpdateRoleView role);
        public RoleView GetRole(int roleId);
    }
}
