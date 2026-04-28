using FlightBooking.DTOs.CheckInDTOs;

namespace FlightBooking.Services.CheckInServices
{
    public interface ICheckInService
    {
        Task CompleteCheckInAsync(CompleteCheckInDTO completeCheckInDTO);
    }
}