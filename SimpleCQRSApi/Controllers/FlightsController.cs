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

            try
            {
                var flightDetails = await _mediator.Send(new GetFlightDetailsQuery(request));
                ApiResponnse response = new ApiResponnse { Ok = true, Result = flightDetails };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        } 
    }
}