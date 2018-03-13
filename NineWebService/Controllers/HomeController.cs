using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NineWebService.Models;

namespace NineWebService.Controllers
{
    [Produces("application/json")]
    [Route("api/Data")]
    public class HomeController : Controller
    {
        [HttpPost]
        public IActionResult Index([FromBody]Root root)
        {
            return Ok();
        }
    }
}
