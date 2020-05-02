using Microsoft.AspNetCore.Mvc;
using PayMeForYou.Backend.Library.Services.Interface;
using PayMeForYou.Entity.Views.Role;
using System.Threading.Tasks;

namespace PayMeForYou.Backend.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _service;
        public RoleController(IRoleService roleService)
        {
            _service = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> Management()
        {
            var view = await _service.GetRolesAsync();

            return PartialView(view);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var view = new CreateRoleView
            {
                PermissionSections = _service.GetAllPermissionSections()
            };

            return PartialView(view);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleView view)
        {
            await _service.CreateRoleAsync(view);

            return Content("create successfully");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var role = await _service.GetRoleAsync(id);

            var view = new UpdateRoleView
            {
                Id = role.Id,
                Description = role.Description,
                RoleName = role.RoleName,
                PermissionSections = _service.GetAllPermissionSections(role.Permissions)
            };

            return PartialView(view);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRoleView view)
        {
            await _service.UpdateRoleAsync(view);

            return Content("update successfully");
        }
    }
}