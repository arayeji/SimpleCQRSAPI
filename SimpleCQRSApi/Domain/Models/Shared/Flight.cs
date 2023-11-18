using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FlightBookingAPI.Domain.Models.DataSets
{

    public class Flight
    {
        [Key]

        public Guid Id { get; set; } = Guid.NewGuid();
        public string? number { get; set; }

        public string? iata { get; set; }

        public string? icao { get; set; }
        // public CodeShared codeshared { get; set; }
        // [AllowNull]
        // public Guid? codesharedId { get; set; }
        public List<FlightDetails> FlightDetails { get; set; }
    }
}