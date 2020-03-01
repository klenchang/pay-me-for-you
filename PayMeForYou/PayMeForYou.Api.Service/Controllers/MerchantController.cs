using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PayMeForYou.Api.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchantController : ControllerBase
    {
        [HttpGet]
        [Route("name/{id?}")]
        public string GetMerchantName(int id)
        {
            return $"Klen:{id}";
        }
        [HttpGet]
        public string Index() => "Merchant Api";
    }
}