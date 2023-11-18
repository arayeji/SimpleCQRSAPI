using FlightBookingAPI.Domain.Models.DataSets;
using FlightBookingAPI.Queries;

namespace FlightBookingAPI.Repositories
{
    public interface IFlightDetailsRepository
    {
        public Task<List<FlightDetails>> Get(GetFlightDetailsQuery Query);
        public Task<int> BulkInsert(List<FlightDetails> flightDetails);
        //public Task<FlightDetails> Add(FlightDetails flight);
        //public Task<int> Update(FlightDetails flight);
    }
}
