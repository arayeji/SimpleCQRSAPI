using System.Data.Common;

namespace FlightBookingAPI.Domain.Models
{
    public class SearchParameters
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public SearchOperators Operator { get; set; }
        public enum SearchOperators
        {
            Equal,
            GreaterThan,
            LessThan,
            LessThanOrEqual,
            GreaterThanOrEqual,
            Like
        }
    }
}
