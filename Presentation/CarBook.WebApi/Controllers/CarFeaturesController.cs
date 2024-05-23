using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{CarId}")]
        public async Task<IActionResult> GetCarFeatureByCarIdList(int CarId)
        {
            return Ok(await _mediator.Send(new GetCarFeatureByCarIdQuery(CarId)));
        }

        [HttpGet("CarFeatureChangeAvaliableFalse/{id}")]
        public async Task<IActionResult> CarFeatureChangeAvaliableFalse(int id)
        {
            await _mediator.Send(new UpdateCarFeatureAvaliableChangeToFalseCommand(id));
            return Ok("Başarıyla Güncellenmiştir");
        }

        [HttpGet("CarFeatureChangeAvaliableTrue/{id}")]
        public async Task<IActionResult> CarFeatureChangeAvaliableTrue(int id)
        {
            await _mediator.Send(new UpdateCarFeatureAvaliableChangeToTrueCommand(id));
            return Ok("Başarıyla Güncellenmiştir");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCar(CreateCarFeatureByCarCommand createCarFeatureByCarCommand)
        {
            await _mediator.Send(createCarFeatureByCarCommand);
            return Ok("Araç Özelliği Başarıyla Eklenmiştir");
        }
    }
}
