using PayMeForYou.Entity.RepositoryModules;
using PayMeForYou.Service.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Service.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public async Task CreateRoleAsync(Role role)
        {
            await Task.Run(() => throw new System.NotImplementedException());
        }

        public async Task UpdateRoleAsync(Role role)
        {
            await Task.Run(() => throw new System.NotImplementedException());
        }

        public async Task<Role> GetRoleAsync(int roleId)
        {
            return await Task.Run(() => new Role());
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            var list = new List<Role>
            {
                new Role{ Id = 1, RoleName = "Merchant", Description = "Merchant Admin", Permissions = "Merchant Permissions" },
                new Role{ Id = 2, RoleName = "Affiliate", Description = "Affiliate Admin", Permissions = "Affiliate Permissions" },
                new Role{ Id = 3, RoleName = "Manager", Description = "", Permissions = "Manager Permissions" },
            };
            return await Task.Run(() => list);
        }
    }
}
