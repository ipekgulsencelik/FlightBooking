using AutoMapper;
using FlightBooking.DTOs.FlightDTOs;
using FlightBooking.Entities;
using FlightBooking.Settings;
using MongoDB.Driver;

namespace FlightBooking.Services.FlightServices
{
    public class FlightService : IFlightService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Flight> _flightCollection;

        public FlightService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _flightCollection = database.GetCollection<Flight>(_databaseSettings.FlightCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFlightAsync(CreateFlightDTO createFlightDTO)
        {
            var flightEntity = _mapper.Map<Flight>(createFlightDTO);
            await _flightCollection.InsertOneAsync(flightEntity);
        }

        public async Task DeleteFlightAsync(string id)
        {
            await _flightCollection.DeleteOneAsync(flight => flight.FlightId == id);
        }

        public async Task<List<ResultFlightDTO>> GetAllFlightsAsync()
        {
            var flights = await _flightCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFlightDTO>>(flights);
        }

        public async Task<GetFlightByIdDTO> GetFlightByIdAsync(string id)
        {
            var flight = await _flightCollection.Find(flight => flight.FlightId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetFlightByIdDTO>(flight);
        }

        public async Task UpdateFlightAsync(UpdateFlightDTO updateFlightDTO)
        {
            var flightEntity = _mapper.Map<Flight>(updateFlightDTO);
            await _flightCollection.FindOneAndReplaceAsync(flight => flight.FlightId == updateFlightDTO.FlightId, flightEntity);
        }
    }
}