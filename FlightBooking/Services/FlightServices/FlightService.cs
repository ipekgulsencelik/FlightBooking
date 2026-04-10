using AutoMapper;
using FlightBooking.DTOs.FlightDTOs;
using FlightBooking.DTOs.PassengerDTOs;
using FlightBooking.Entities;
using FlightBooking.Settings;
using MongoDB.Driver;

namespace FlightBooking.Services.FlightServices
{
    public class FlightService : IFlightService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Flight> _flightCollection;
        private readonly IMongoCollection<Booking> _bookingCollection;

        public FlightService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _flightCollection = database.GetCollection<Flight>(_databaseSettings.FlightCollectionName);
            _bookingCollection = database.GetCollection<Booking>(_databaseSettings.BookingCollectionName);
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

        public async Task<List<PassengerListItemDTO>> GetFlightDetailsWithPassengers(string id)
        {
            // 1. O uçuşa ait tüm booking'leri çek
            var bookings = await _bookingCollection.Find(x => x.FlightId == id).ToListAsync();

            // 2. Her booking içindeki yolcuları düzleştir ve DTO'ya map et
            var passengers = bookings
                .SelectMany(b => b.Passengers.Select(p => new PassengerListItemDTO
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = b.ContactEmail,   // yolcuya ait email yoksa iletişim emaili kullan
                    Gender = p.Gender,
                    PassengerType = p.PassengerType,
                    Pnr = b.BookingId,       // PNR olarak BookingId kullanılıyor
                    Phone = b.ContactPhone,
                    // Aşağıdaki alanlar Passenger entity'nde varsa doğrudan al
                    SeatNumber = p.SeatNumber,
                    CheckInStatus = p.CheckInStatus,
                    // PaymentStatus = b.PaymentStatus,
                    TicketStatus = p.TicketStatus,
                }))
                .ToList();

            return passengers;
        }

        public async Task UpdateFlightAsync(UpdateFlightDTO updateFlightDTO)
        {
            var flightEntity = _mapper.Map<Flight>(updateFlightDTO);
            await _flightCollection.FindOneAndReplaceAsync(flight => flight.FlightId == updateFlightDTO.FlightId, flightEntity);
        }
    }
}