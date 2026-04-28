using FlightBooking.DTOs.BookingDTOs;

namespace FlightBooking.Services.BookingServices
{
    public interface IBookingService
    {
        Task CreateBookingAsync(CreateBookingDTO createBookingDTO);
        Task<(string Name, string Surname)> GetPassengerNameByIdAsync(string passengerId);
        Task<string> GetPnrByPassengerIdAsync(string passengerId);
        Task<string> GetGateByPassengerIdAsync(string passengerId);
    }
}