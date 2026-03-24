using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.ViewComponents
{
    public class _AdminTopBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}