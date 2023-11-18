namespace FlightBookingAPI.Domain.Models
{
    public class AviationEndPoint
    {
        public string Name { get; set; }
        public string BaseURL { get; set; }
        public List<AviationEndPointParameter> Parameters { get; set; }
    }
}
