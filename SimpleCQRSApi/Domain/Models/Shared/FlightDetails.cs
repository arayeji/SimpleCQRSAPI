using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FlightBookingAPI.Domain.Models.DataSets
{
    public class FlightDetails
    {
        [Key]

        public Guid Id { get; set; } = Guid.NewGuid();
        [AllowNull]
        public string? flight_date { get; set; }
        [AllowNull]
        public string? flight_status { get; set; }
        //[AllowNull]
        //public Guid? departureId { get; set; }
        //[AllowNull]
        //public Guid? arrivalId { get; set; }
        //[AllowNull]
        //public Guid? airlineId { get; set; }
        //[AllowNull]
        //public Guid? flightId { get; set; }
        //public Departure departure { get; set; }
        //public Arrival arrival { get; set; }
        //public Airline airline { get; set; }
        //public Flight flight { get; set; }
        [AllowNull]
        public string? aircraft { get; set; }
        [AllowNull]
        public string? live { get; set; }
    }
}
