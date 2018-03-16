using DataService.Abstractions;
using Microsoft.AspNetCore.Mvc;
using NineWebService.Models;

namespace NineWebService.Controllers
{
    /// <summary>
    /// Contains API endpoints to process request data.
    /// </summary>
    [Produces("application/json")]
    public class HomeController : Controller
    {
        private IDataProcessor<Payload> _dataService;

        public HomeController(IDataProcessor<Payload> dataService)
        {
            _dataService = dataService;
        }

        /// <summary>
        ///     Default action for Home Page
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     API endpoint to get and process request data
        /// </summary>
        /// <param name="requestData">Shows data to be processed</param>
        /// <returns>Response data with processed shows</returns>
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
