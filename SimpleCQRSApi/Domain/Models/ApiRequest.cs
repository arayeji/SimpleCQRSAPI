namespace FlightBookingAPI.Domain.Models
{
    public  class ApiRequest
    {
        public PaginationParameters PaginationParameters { get; set; }
        public List<SearchParameters> SearchParameters { get; set; }
    }
}
