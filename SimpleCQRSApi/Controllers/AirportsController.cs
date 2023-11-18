using FlightBookingAPI.Domain.Models;
using FlightBookingAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingAPI.Controllers
{
    [ApiController]
    [Route("api/airports")]
    public class AirportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AirportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> GetAirports([FromBody] ApiRequest request)
        {
            try
            {
                var airports = await _mediator.Send(new GetAirportsQuery(request));
                ApiResponnse response = new ApiResponnse { Ok = true, Result = airports };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }

        }
    }
}