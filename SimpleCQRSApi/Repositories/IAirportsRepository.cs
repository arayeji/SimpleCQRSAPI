using FlightBookingAPI.Domain.Models.DataSets;
using FlightBookingAPI.Queries;

namespace FlightBookingAPI.Repositories
{
    public interface IAirportsRepository
    {
        public Task<List<Airport>> Get(GetAirportsQuery Query);
        public Task<int> BulkInsert(List<Airport> Airports);
        //public Task<FlightDetails> Add(FlightDetails flight);
        //public Task<int> Update(FlightDetails flight);
    }
}
