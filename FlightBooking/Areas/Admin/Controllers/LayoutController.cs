using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class LayoutController : Controller
    {
        public IActionResult AdminLayout()
        {
            return View();
        }
    }
}