using FlightBooking.DTOs.FlightDTOs;

namespace FlightBooking.Services.FlightServices
{
    public interface IFlightService
    {
        Task<List<ResultFlightDTO>> GetAllFlightsAsync();
        Task<GetFlightByIdDTO> GetFlightByIdAsync(string id);
        Task CreateFlightAsync(CreateFlightDTO createFlightDTO);
        Task DeleteFlightAsync(string id);
        Task UpdateFlightAsync(UpdateFlightDTO updateFlightDTO);
    }
}