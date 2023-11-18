using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightBookingAPI.Domain.Models.DataSets
{

    public class Arrival
    {
        [Key]

        public Guid Id { get; set; } = Guid.NewGuid();
        public string? airport { get; set; }
        public string? timezone { get; set; }
        public string? iata { get; set; }
        public string? icao { get; set; }
        public string? terminal { get; set; }
        public string? gate { get; set; }
        public string? baggage { get; set; }
        public int? delay { get; set; }
        public DateTime scheduled { get; set; }
        public DateTime estimated { get; set; }
        public string? actual { get; set; }
        public string? estimated_runway { get; set; }
        public string? actual_runway { get; set; }
        public List<FlightDetails> FlightDetails { get; set; }
    }
}