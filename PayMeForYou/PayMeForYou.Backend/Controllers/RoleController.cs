using Microsoft.AspNetCore.Mvc;
using PayMeForYou.Entity.Enums;
using PayMeForYou.Entity.Views.Role;
using System.Collections.Generic;

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
        public IActionResult Create()
        {
            var view = new CreateRoleView
            {
                PermissionSections = new List<PermissionSection>
                {
                    new PermissionSection
                    {
                        SectionName = "Merchant",
                        Permissions = new List<Entity.Entities.CustomCheckBoxItem>
                        {
                            new Entity.Entities.CustomCheckBoxItem { Id = Permission.CREATE_MERCHANT.ToString(), Text = Permission.CREATE_MERCHANT.ToString(), Selected = false },
                            new Entity.Entities.CustomCheckBoxItem { Id = Permission.UPDATE_MERCHANT.ToString(), Text = Permission.UPDATE_MERCHANT.ToString(), Selected = false },
                            new Entity.Entities.CustomCheckBoxItem { Id = Permission.VIEW_MERCHANT.ToString(), Text = Permission.VIEW_MERCHANT.ToString(), Selected = false }
                        }
                    },
                    new PermissionSection
                    {
                        SectionName = "User",
                        Permissions = new List<Entity.Entities.CustomCheckBoxItem>
                        {
                            new Entity.Entities.CustomCheckBoxItem { Id = Permission.CREATE_USER.ToString(), Text = Permission.CREATE_USER.ToString(), Selected = false },
                            new Entity.Entities.CustomCheckBoxItem { Id = Permission.UPDATE_USER.ToString(), Text = Permission.UPDATE_USER.ToString(), Selected = false },
                            new Entity.Entities.CustomCheckBoxItem { Id = Permission.VIEW_USER.ToString(), Text = Permission.VIEW_USER.ToString(), Selected = false }
                        }
                    }
                }
            };

            return PartialView(view);
        }

        [HttpPost]
        public IActionResult Create(CreateRoleView view)
        {
            return PartialView(view);
        }
    }
}