using CarBook.Application.Features.Editör.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarPricingList()
        {
            var values = await _mediator.Send(new GetCarWithPricingQuery());
            return Ok(values);
        }

		[HttpGet("GetCarPricingWithTimePeriod")]
		public async Task<IActionResult> GetCarPricingWithTimePeriod()
		{
			var values = await _mediator.Send(new GetCarPricingWithTimePeriodQuery());
			return Ok(values);
		}
	}
}
