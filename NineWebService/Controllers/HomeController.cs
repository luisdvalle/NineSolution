using DataService.Abstractions;
using Microsoft.AspNetCore.Mvc;
using NineWebService.Models;

namespace NineWebService.Controllers
{
    [Produces("application/json")]
    public class HomeController : Controller
    {
        private IDataProcessor<Payload> _dataService;

        public HomeController(IDataProcessor<Payload> dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody]RequestData requestData)
        {
            if (requestData == null)
            {
                return BadRequest( new { error = "Could not decode request: JSON parsing failed" } );
            }

            if (requestData.Payload == null)
            {
                return Ok(new ResponseData { Response = null });
            }

            var res = _dataService.ProcessRequestData(requestData.Payload);

            ResponseData response = new ResponseData()
            {
                Response = res as Show[]
            };

            return Ok(response);
        }
    }
}
