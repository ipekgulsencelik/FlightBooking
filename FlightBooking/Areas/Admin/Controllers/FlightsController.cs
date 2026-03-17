using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class FlightsController : Controller
    {
        public IActionResult FlightList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateFlight()
        {
            return View();
        }
    }
}