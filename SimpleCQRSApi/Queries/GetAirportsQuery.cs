using FlightBookingAPI.Domain.Models;
using FlightBookingAPI.Domain.Models.DataSets;
using MediatR;

namespace FlightBookingAPI.Queries
{
    public class GetAirportsQuery : IRequest<List<Airport>>
    {
        public ApiRequest apiRequest { get; set; }
        public GetAirportsQuery(ApiRequest apiRequest)
        {
            this.apiRequest = apiRequest;
        }
    }
}
