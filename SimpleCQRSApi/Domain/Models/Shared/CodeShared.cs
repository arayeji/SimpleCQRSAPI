using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightBookingAPI.Domain.Models.DataSets
{
    public class CodeShared
    {
        [Key]

        public Guid Id { get; set; } = Guid.NewGuid();
        public string airline_name { get; set; }
        public string airline_iata { get; set; }
        public string airline_icao { get; set; }
        public string flight_number { get; set; }
        public string flight_iata { get; set; }
        public string flight_icao { get; set; }
        public List<Flight> Flights { get; set; }
    }
}
