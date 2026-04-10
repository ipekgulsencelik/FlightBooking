using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CheckInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}