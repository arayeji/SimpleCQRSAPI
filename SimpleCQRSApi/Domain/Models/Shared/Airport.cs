using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FlightBookingAPI.Domain.Models.DataSets
{
    public class Airport
    {
        [Key]
        public int Id { get; set; }
        public string airport_name { get; set; }
        public string iata_code { get; set; }
        public string icao_code { get; set; }
        [AllowNull]
        public string? latitude { get; set; }
        [AllowNull]
        public string? longitude { get; set; }
        [AllowNull]
        public string? geoname_id { get; set; }
        [AllowNull]
        public string? timezone { get; set; }
        [AllowNull]
        public string? gmt { get; set; }
        [AllowNull]
        public string? phone_number { get; set; }
        [AllowNull]
        public string? country_name { get; set; }
        [AllowNull]
        public string? country_iso2 { get; set; }
        [AllowNull]
        public string? city_iata_code { get; set; }
    }
}
