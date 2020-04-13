using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PayMeForYou.Backend.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Profile()
        {
            return PartialView();
        }
        
        [HttpGet]
        public IActionResult Password()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult Management()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult CustomerControl()
        {
            return PartialView();
        }
    }
}