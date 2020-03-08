using Microsoft.AspNetCore.Mvc;
using PayMeForYou.Entity.Views.Role;
using PayMeForYou.Service.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleService service;
        public RoleController(IRoleService roleService)
        {
            service = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRolesAsync()
        {
            var list = new List<RoleView>
            {
                new RoleView{ Id = 1, RoleName = "Merchant", Description = "Merchant Admin", RowNo = 1, Permissions = "Merchant Permissions" },
                new RoleView{ Id = 2, RoleName = "Affiliate", Description = "Affiliate Admin", RowNo = 2, Permissions = "Affiliate Permissions" },
                new RoleView{ Id = 3, RoleName = "Manager", Description = "", RowNo = 3, Permissions = "Manager Permissions" },
            };
            return await Task.Run(() => Ok(list));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRoleAsync(int id)
        {
            var role = service.GetRole(id);
            if (role == null) 
                return await Task.Run(() => NotFound());

            return await Task.Run(() => Ok(role));
        }
        [HttpPost]
        public async Task CreateRole([FromBody] CreateRoleView role)
        {
            await Task.Run(() => Ok());
        }
        [HttpPut]
        public async Task UpdateRole([FromBody] UpdateRoleView role)
        {
            await Task.Run(() => Ok());
        }
    }
}