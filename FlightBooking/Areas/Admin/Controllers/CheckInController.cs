using FlightBooking.DTOs.CheckInDTOs;
using FlightBooking.Services.BookingServices;
using FlightBooking.Services.CheckInServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CheckInController : Controller
    {
        private readonly ICheckInService _checkInService;
        private readonly IBookingService _bookingService;

        public CheckInController(IBookingService bookingService, ICheckInService checkInService)
        {
            _bookingService = bookingService;
            _checkInService = checkInService;
        }

        public async Task<IActionResult> Index(string id)
        {
            ViewBag.FlightNumber = TempData["FlightNumber"];
            ViewBag.DepartureTime = TempData["DepartureTime"];
            ViewBag.ArrivalTime = TempData["ArrivalTime"];

            var passenger = await _bookingService.GetPassengerNameByIdAsync(id);
            var pnrNumber = await _bookingService.GetPnrByPassengerIdAsync(id);
            var gate = await _bookingService.GetGateByPassengerIdAsync(id);

            ViewBag.Name = passenger.Name;
            ViewBag.Surname = passenger.Surname;
            ViewBag.PnrNumber = pnrNumber;
            ViewBag.Gate = gate;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CompleteCheckInDTO completeCheckInDTO)
        {
            await _checkInService.CompleteCheckInAsync(completeCheckInDTO);

            return RedirectToAction("Test");
        }
    }
}