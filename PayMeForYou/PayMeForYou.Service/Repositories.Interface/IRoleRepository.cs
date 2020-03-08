using PayMeForYou.Entity.RepositoryModules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Service.Repositories.Interface
{
    public interface IRoleRepository
    {
        public Task<List<Role>> GetRolesAsync();
        public Task CreateRoleAsync(Role role);
        public Task UpdateRoleAsync(Role role);
        public Task<Role> GetRoleAsync(int roleId);
    }
}
