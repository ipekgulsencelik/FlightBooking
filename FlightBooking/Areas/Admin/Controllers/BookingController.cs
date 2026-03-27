using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BookingController : Controller
    {
        public IActionResult BookingList()
        {
            return View();
        }

        public IActionResult CreateBooking()
        {
            return View();
        }
    }
}