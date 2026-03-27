namespace FlightBooking.Entities
{
    public class Passenger
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; } // Male, Female
        public string PassengerType { get; set; } // Adult, Child, Infant
    }
}