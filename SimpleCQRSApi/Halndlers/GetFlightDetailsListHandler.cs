using FlightBookingAPI.Domain.Models.DataSets;
using FlightBookingAPI.Queries;
using FlightBookingAPI.Repositories;
using MediatR;

namespace FlightBookingAPI.Halndlers
{
    public class GetFlightDetailsListHandler : IRequestHandler<GetFlightDetailsQuery, List<FlightDetails>>
    {
        private readonly IFlightDetailsRepository _flightDetailsRepository;


        public GetFlightDetailsListHandler(IFlightDetailsRepository flightDetailsRepository)
        {
            _flightDetailsRepository = flightDetailsRepository;
        }

        public async Task<List<FlightDetails>> Handle(GetFlightDetailsQuery query, CancellationToken cancellationToken)
        {
            return await _flightDetailsRepository.Get(query);
        }
         
    }
}
