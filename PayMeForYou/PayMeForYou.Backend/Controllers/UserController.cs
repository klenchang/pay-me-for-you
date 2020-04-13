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
            return View();
        }
        
        [HttpGet]
        public IActionResult Password()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Management()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CustomerControl()
        {
            return View();
        }
    }
}