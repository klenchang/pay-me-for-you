using Microsoft.AspNetCore.Mvc;
using PayMeForYou.Entity.Views.Role;
using PayMeForYou.Service.Services.Interface;
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
            var list = await service.GetRolesAsync();

            return await Task.Run(() => Ok(list));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRoleAsync(int id)
        {
            var role = service.GetRoleAsync(id);
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