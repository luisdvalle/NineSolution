using Microsoft.AspNetCore.Mvc;
using NineWebService.Abstractions;
using NineWebService.Models;
using System.Json;

namespace NineWebService.Controllers
{
    [Produces("application/json")]
    public class HomeController : Controller
    {
        private IDataService _dataService;

        public HomeController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost]
        public IActionResult Index([FromBody]RequestData requestData)
        {
            if (requestData == null)
            {
                return BadRequest
                    (
                    new
                    {
                        error = "Could not decode request: JSON parsing failed"
                    }
                    );
            }

            Response responseData = _dataService.ProcessIncomingShowData(requestData);

            return Ok(responseData);
        }
    }
}
