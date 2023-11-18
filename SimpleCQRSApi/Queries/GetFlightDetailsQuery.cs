using FlightBookingAPI.Domain.Models;
using FlightBookingAPI.Domain.Models.DataSets;
using MediatR;

namespace FlightBookingAPI.Queries
{
    public class GetFlightDetailsQuery : IRequest<List<FlightDetails>>
    {
        public ApiRequest apiRequest { get; set ; }
        public GetFlightDetailsQuery(ApiRequest apiRequest)
        {
            this.apiRequest = apiRequest;
        }
    }
}
