using PayMeForYou.Entity.Views.Role;
using System.Collections.Generic;

namespace PayMeForYou.Service.Services.Interface
{
    public interface IRoleService
    {
        public List<RoleView> GetRoles();
        public void CreateUser(CreateRoleView role);
        public void EditUser(EditRoleView role);
        public RoleView GetUser(int roleId);
    }
}
