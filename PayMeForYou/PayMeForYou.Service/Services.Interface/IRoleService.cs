using PayMeForYou.Entity.Views.Role;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Service.Services.Interface
{
    public interface IRoleService
    {
        public Task<List<RoleView>> GetRolesAsync();
        public Task<int> CreateRoleAsync(CreateRoleView roleView);
        public Task<int> UpdateRoleAsync(UpdateRoleView roleView);
        public Task<RoleView> GetRoleAsync(int roleId);
    }
}
