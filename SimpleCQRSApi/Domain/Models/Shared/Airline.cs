
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightBookingAPI.Domain.Models.DataSets
{
    public class Airline
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? name { get; set; }
        public string? iata { get; set; }
        public string? icao { get; set; }
        public List<FlightDetails> FlightDetails { get; set; }

    }
}
