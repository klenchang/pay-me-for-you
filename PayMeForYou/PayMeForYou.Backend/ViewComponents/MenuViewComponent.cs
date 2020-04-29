using Microsoft.AspNetCore.Mvc;
using PayMeForYou.Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayMeForYou.Backend.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await Task.Run(() => new List<MenuViewModel>
            {
                new MenuViewModel { CategoryName = "Home", ControllerName = "home", ActionName = "index", FunctionName = "", IsRoot = true },
                new MenuViewModel { CategoryName = "User", ControllerName = "user", ActionName = "management", FunctionName = "Management", IsRoot = false },
                new MenuViewModel { CategoryName = "User", ControllerName = "user", ActionName = "create", FunctionName = "Create", IsRoot = false },
                new MenuViewModel { CategoryName = "User", ControllerName = "user", ActionName = "customercontrol", FunctionName = "Customer Control", IsRoot = false },
                new MenuViewModel { CategoryName = "Role", ControllerName = "role", ActionName = "management", FunctionName = "Management", IsRoot = false },
                new MenuViewModel { CategoryName = "Role", ControllerName = "role", ActionName = "create", FunctionName = "Create", IsRoot = false },
                new MenuViewModel { CategoryName = "Test", ControllerName = "test", ActionName = "index", FunctionName = "", IsRoot = true },
            });
            return View(model);
        }
    }
}
