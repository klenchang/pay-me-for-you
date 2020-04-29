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
        public IActionResult Management()
        {
            return PartialView();
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

            return Content("success");
        }
    }
}