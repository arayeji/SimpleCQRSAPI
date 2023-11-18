using MediatR;

namespace FlightBookingAPI.Commands
{
    public class CreateFlightCommand : IRequest
    {
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        // Other properties
    }
}
