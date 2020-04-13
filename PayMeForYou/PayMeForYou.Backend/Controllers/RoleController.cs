using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PayMeForYou.Entity.Views.Role;

namespace PayMeForYou.Backend.Controllers
{
    public class RoleController : Controller
    {
        [HttpGet]
        public IActionResult Management()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult Create(CreateRoleView view)
        {
            return PartialView(view);
        }
    }
}