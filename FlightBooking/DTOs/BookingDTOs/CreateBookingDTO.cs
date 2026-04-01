using FlightBooking.DTOs.PassengerDTOs;

namespace FlightBooking.DTOs.BookingDTOs
{
    public class CreateBookingDTO
    {
        public string FlightId { get; set; }

        public List<CreatePassengerDTO> Passengers { get; set; }

        public string ContactEmail { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
    }
}