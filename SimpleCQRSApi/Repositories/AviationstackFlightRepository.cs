using FlightBookingAPI.Domain.Models;
using FlightBookingAPI.Domain.Models.AviationStackApi;
using FlightBookingAPI.Domain.Models.DataSets;
using FlightBookingAPI.Queries;
using Microsoft.AspNetCore.Http;
using System.Configuration;
using System.Net;

namespace FlightBookingAPI.Repositories
{
    public class AviationstackFlightRepository : IFlightDetailsRepository
    {
        protected readonly IConfiguration Configuration;

        public AviationstackFlightRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Task<int> BulkInsert(List<FlightDetails> flight)
        {
            throw new NotSupportedException();
        }

        public async Task<List<FlightDetails>> Get(GetFlightDetailsQuery Query)
        {
            AviationEndPoint endpoint  = Configuration.GetSection("AviationEndPoints").Get<List<AviationEndPoint>>().Find(Endpoint => Endpoint.Name == "aviationstack.com-flights");
            if (Query.apiRequest.PaginationParameters.Pagination)
            {
                if (Query.apiRequest.PaginationParameters.PageSize.HasValue)
                {
                    endpoint.Parameters.Add(new AviationEndPointParameter { Name = "limit", Value = Query.apiRequest.PaginationParameters.PageSize.Value.ToString() });
                }
                if (Query.apiRequest.PaginationParameters.PageNumber.HasValue)
                {
                    endpoint.Parameters.Add(new AviationEndPointParameter { Name = "offset", Value = Query.apiRequest.PaginationParameters.SkipCalculation().ToString() });
                }
            }


            string queryString = $"{string.Join("&", endpoint.Parameters.Select(p=> $"{p.Name}={p.Value}"))}";

            string proxyAddress = "192.168.6.244";
            int proxyPort = 808;
            HttpClientHandler handler = new HttpClientHandler
            {
                Proxy = new WebProxy(proxyAddress, proxyPort)
            };

            using (HttpClient client = new HttpClient(handler))
            {
                string requestUri = $"{endpoint.BaseURL}?&{queryString}";
              
                HttpResponseMessage response = await client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    var apiResult = await response.Content.ReadFromJsonAsync<AviationstackApiResponse>();

                    return apiResult.Data;
                    
                }
                else
                { throw new Exception($"Getting data from API Failed: {response.StatusCode}\r\n{response.ReasonPhrase}"); }
            }
          
        }
    }
}
