using PayMeForYou.Entity.RepositoryModules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Api.Service.Library.Repositories.Interface
{
    public interface IRoleRepository
    {
        public Task<List<Role>> GetRolesAsync();
        public Task<int> CreateRoleAsync(Role role);
        public Task<int> UpdateRoleAsync(Role role);
        public Task<Role> GetRoleAsync(int roleId);
    }
}
