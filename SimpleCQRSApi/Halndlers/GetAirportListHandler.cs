using FlightBookingAPI.Domain.Models.DataSets;
using FlightBookingAPI.Queries;
using FlightBookingAPI.Repositories;
using MediatR;

namespace FlightBookingAPI.Halndlers
{
    public class GetAirportListHandler : IRequestHandler<GetAirportsQuery, List<Airport>>
    {
        private readonly IAirportsRepository _airportsRepository;


        public GetAirportListHandler(IAirportsRepository airportsRepository)
        {
            _airportsRepository = airportsRepository;
        }

        public async Task<List<Airport>> Handle(GetAirportsQuery query, CancellationToken cancellationToken)
        {
            return await _airportsRepository.Get(query);
        }

    }
}
