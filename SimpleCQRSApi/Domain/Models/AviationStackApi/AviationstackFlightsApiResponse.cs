using FlightBookingAPI.Domain.Models.DataSets;

namespace FlightBookingAPI.Domain.Models.AviationStackApi
{
    public class AviationstackApiResponse
    {
        public List<FlightDetails> Data { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
    }
}
