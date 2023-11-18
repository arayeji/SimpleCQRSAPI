using FlightBookingAPI.Controllers;
using FlightBookingAPI.Domain.Models;
using FlightBookingAPI.Domain.Models.DataSets;
using FlightBookingAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FlightBookingApiTest
{
    public class FlightBookingApiControllersTest
    {
        [Fact]
        public async Task GetAirports_ReturnsOkResultWithAirportList()
        {
            var mockMediator = new Mock<IMediator>();
            var expectedAirports = new List<Airport>
            {
                new Airport { Id = 1},new Airport { Id = 2},new Airport { Id = 3},new Airport { Id = 4}
            };
            mockMediator.Setup(m => m.Send(It.IsAny<GetAirportsQuery>(), default(CancellationToken)))
                .ReturnsAsync(expectedAirports);

            var controller = new AirportsController(mockMediator.Object);

            var result = await controller.GetAirports(new ApiRequest { PaginationParameters = new PaginationParameters { Pagination = false } });

            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Airport>>(okResult.Value);

            Assert.Equal(expectedAirports.Count, model.Count());
        }
    }

}
