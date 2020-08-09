using Microsoft.AspNetCore.Mvc;
using PayMeForYou.Api.Service.Library.Services.Interface;
using System.Threading.Tasks;

namespace PayMeForYou.Api.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService userService)
        {
            _service = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var list = await _service.GetUsersAsync("", 1);

            return await Task.Run(() => Ok(list));
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
