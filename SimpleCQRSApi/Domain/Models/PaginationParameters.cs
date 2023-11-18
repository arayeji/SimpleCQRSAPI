namespace FlightBookingAPI.Domain.Models
{
    public class PaginationParameters
    {
        public bool Pagination { get; set; }
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 100;
        public string? SortBy { get; set; } = "Id"; 
        public bool? SortDescending { get; set; } = false;
        public int SkipCalculation()
        {
            if(PageNumber != null && PageSize != null)
            return PageNumber.Value * PageSize.Value;
            else return 0;
        }
    }

}
