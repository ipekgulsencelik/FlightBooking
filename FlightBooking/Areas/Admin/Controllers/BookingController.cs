using FlightBooking.DTOs.BookingDTOs;
using FlightBooking.Services.BookingServices;
using FlightBooking.Services.FlightServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BookingController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IBookingService _bookingService;
        
        public BookingController(IFlightService flightService, IBookingService bookingService)
        {
            _flightService = flightService;
            _bookingService = bookingService;
        }

        public IActionResult BookingList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateBooking(string id)
        {
            var value = await _flightService.GetFlightByIdAsync(id);

            ViewBag.id = id;
            ViewBag.FlightNumber = value.FlightNumber;
            ViewBag.DepartureAirportCode = value.DepartureAirportCode;
            ViewBag.DepartureAirportName = value.DepartureAirportName;
            ViewBag.ArrivalAirportCode = value.ArrivalAirportCode;
            ViewBag.ArrivalAirportName = value.ArrivalAirportName;
            ViewBag.DepartureTime = value.DepartureTime;
            ViewBag.ArrivalTime = value.ArrivalTime;
            ViewBag.AirlineCode = value.AirlineCode;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDTO createBookingDTO)
        {
            await _bookingService.CreateBookingAsync(createBookingDTO);
            return RedirectToAction("BookingList", "Booking", new { area = "Admin" });
        }
    }
}