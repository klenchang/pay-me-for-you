using PayMeForYou.Entity.RepositoryModules;
using PayMeForYou.Entity.Views.Role;
using PayMeForYou.Service.Repositories.Interface;
using PayMeForYou.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository repository;
        public RoleService(IRoleRepository roleRepository)
        {
            repository = roleRepository;
        }
        public async Task CreateRoleAsync(CreateRoleView roleView)
        {
            var role = new Role
            {
                RoleName = roleView.RoleName,
                Description = roleView.Description,
                Permissions = roleView.Permissions,
                CreatedBy = roleView.CreatedBy,
                CreatedTime = DateTime.UtcNow
            };
            await repository.CreateRoleAsync(role);
        }

        public async Task<RoleView> GetRoleAsync(int roleId)
        {
            var role = await repository.GetRoleAsync(roleId);
            return ConvertToView(role, 1);
        }

        public async Task<List<RoleView>> GetRolesAsync()
        {
            var roles = await repository.GetRolesAsync();
            var list = new List<RoleView>();
            for (int i = 1; i <= roles.Count; i++)
                list.Add(ConvertToView(roles[i - 1], i));

            return list;
        }

        public async Task UpdateRoleAsync(UpdateRoleView roleView)
        {
            var role = new Role
            {
                Id = roleView.Id,
                Description = roleView.Description,
                RoleName = roleView.RoleName,
                Permissions = roleView.Permissions,
                UpdatedBy = roleView.UpdatedBy,
                UpdatedTime = DateTime.UtcNow
            };
            await repository.UpdateRoleAsync(role);
        }

        private RoleView ConvertToView(Role role, int rowNo)
        {
            return new RoleView
            {
                Id = role.Id,
                Description = role.Description,
                Permissions = role.Permissions,
                RoleName = role.RoleName,
                RowNo = rowNo
            };
        }
    }
}
