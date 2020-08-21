using PayMeForYou.Entity.Entities;
using PayMeForYou.Entity.RequestModules.Role;
using PayMeForYou.Entity.Views.Role;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Api.Service.Library.Services.Interface
{
    public interface IRoleService
    {
        public Task<List<RoleView>> GetRolesAsync(PagenationSetting pagenationSetting);
        public Task<int> CreateRoleAsync(CreateRoleRequest roleView);
        public Task<int> UpdateRoleAsync(UpdateRoleRequest roleView);
        public Task<RoleView> GetRoleAsync(int roleId);
    }
}
