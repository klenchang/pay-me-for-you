﻿using Microsoft.AspNetCore.Mvc;
using PayMeForYou.Api.Service.Library.Services.Interface;
using PayMeForYou.Entity.RequestModules.Role;
using PayMeForYou.Entity.Views.Role;
using System.Threading.Tasks;

namespace PayMeForYou.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;
        public RoleController(IRoleService roleService)
        {
            _service = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRolesAsync()
        {
            var list = await _service.GetRolesAsync();
            if (list.Count == 0)
                return NoContent();
            else
                return Ok(list);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRoleAsync(int id)
        {
            var role = await _service.GetRoleAsync(id);
            if (role == null)
                return NoContent();
            else
                return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoleAsync([FromBody] CreateRoleRequest role)
        {
            var roidId = await _service.CreateRoleAsync(role);

            return Created($"{Request.Scheme}://{Request.Host}/api/role/{roidId}", null);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoleAsync([FromBody] UpdateRoleRequest role)
        {
            if (await _service.UpdateRoleAsync(role) == 0)
                return NoContent();
            else
                return Ok(new { role.Id });
        }
    }
}