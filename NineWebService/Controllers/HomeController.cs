using Microsoft.AspNetCore.Mvc;
using NineWebService.Abstractions;
using NineWebService.Models;

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
        public IActionResult Index([FromBody]Root root)
        {
            Response responseData = _dataService.ProcessIncomingShowData(root);

            if (responseData == null)
            {
                BadRequest("Could not decode request: JSON parsing failed");
            }

            return Ok(responseData);
        }
    }
}
