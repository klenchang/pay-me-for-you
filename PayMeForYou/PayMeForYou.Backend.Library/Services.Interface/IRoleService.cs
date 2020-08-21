using PayMeForYou.Entity.Entities;
using PayMeForYou.Entity.Views.Role;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Backend.Library.Services.Interface
{
    public interface IRoleService
    {
        public List<PermissionSection> GetAllPermissionSections(string permissions = null);
        public Task CreateRoleAsync(CreateRoleView view);
        public Task<List<RoleView>> GetRolesAsync(PagenationSetting pagenationSetting);
        public Task<RoleView> GetRoleAsync(int id);
        public Task UpdateRoleAsync(UpdateRoleView view);
    }
}
