using FlightBookingAPI.Domain.Models;
using FlightBookingAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingAPI.Controllers
{
    [ApiController]
    [Route("api/flights")]
    public class FlightsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlightsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> GetFlights( [FromBody] ApiRequest request)
        {
           
                var flights = await _mediator.Send(new GetFlightDetailsQuery(request));
                return Ok(flights);
            
        } 
    }
}