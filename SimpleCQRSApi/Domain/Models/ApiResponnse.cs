namespace FlightBookingAPI.Domain.Models
{
    public class ApiResponnse
    {
        public bool Ok { get; set; }
        public string Message { get; set; }
        public dynamic Result { get; set; }
    }
}
