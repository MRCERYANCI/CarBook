using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarDescriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("CarDescriptionByCar/{id}")]
        public async Task<IActionResult> CarDescriptionByCar(int id)
        {
            return Ok(await _mediator.Send(new GetCarDescriptionByCarIdQuery(id)));
        }

    }
}
