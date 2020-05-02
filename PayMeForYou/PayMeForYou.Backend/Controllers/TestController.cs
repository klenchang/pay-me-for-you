using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PayMeForYou.Entity.Entities;
using PayMeForYou.Helper;

namespace PayMeForYou.Backend.Controllers
{
    public class TestController : Controller
    {
        private readonly HttpClientHelper _httpClientHelper;
        public TestController(HttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }
        public async Task<IActionResult> Index()
        {
            _httpClientHelper.Url = "api/role";
            _httpClientHelper.ContentType = HttpEntity.ContentType.Application_Json;
            _httpClientHelper.FormMethod = HttpMethod.Get;

            using var resp = await _httpClientHelper.SubmitAsync();
            var content = await _httpClientHelper.ReadResponseContentAsStringAsync(resp);

            return PartialView();
        }
    }
}