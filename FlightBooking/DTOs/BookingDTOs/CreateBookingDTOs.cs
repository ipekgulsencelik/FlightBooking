using FlightBooking.Entities;

namespace FlightBooking.DTOs.BookingDTOs
{
    public class CreateBookingDTOs
    {
        public string FlightId { get; set; }

        public List<Passenger> Passengers { get; set; }

        public string ContactEmail { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
    }
}