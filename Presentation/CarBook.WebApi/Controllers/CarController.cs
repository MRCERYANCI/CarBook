using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarController : ControllerBase
	{
		private readonly CreateCarCommandHandler _createCarCommandHandler;
		private readonly UpdateCarCommandHandler _updateCarCommandHandler;
		private readonly RemoveCarCommandHandler _removeCarCommandHandler;
		private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
		private readonly GetCarQueryHandler _getCarQueryHandler;
		private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
		private readonly GetLast5CarsWithBrandQueryHandler _getLast5CarsWithBrandQueryHandler;
		private readonly GetCarByIdBarndQueryHandler _getCarByIdBarndQueryHandler;

		public CarController(CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLast5CarsWithBrandQueryHandler getLast5CarsWithBrandQueryHandler, GetCarByIdBarndQueryHandler getCarByIdBarndQueryHandler)
		{
			_createCarCommandHandler = createCarCommandHandler;
			_updateCarCommandHandler = updateCarCommandHandler;
			_removeCarCommandHandler = removeCarCommandHandler;
			_getCarByIdQueryHandler = getCarByIdQueryHandler;
			_getCarQueryHandler = getCarQueryHandler;
			_getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
			_getLast5CarsWithBrandQueryHandler = getLast5CarsWithBrandQueryHandler;
			_getCarByIdBarndQueryHandler = getCarByIdBarndQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> CarList()
		{
			var values = await _getCarQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{CarId}")]
		public async Task<IActionResult> GetCar(int CarId)
		{
			var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(CarId));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCar(CreateCarCommand createCarCommand)
		{
			await _createCarCommandHandler.Handle(createCarCommand);
			return Ok("Araba Bilgisi Başarıyla Eklenmiştir");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveCar(int CarId)
		{
			await _removeCarCommandHandler.Handle(new RemoveCarCommand(CarId));
			return Ok("Araba Başarıyla Silinmiştir");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCar(UpdateCarCommand updateCarCommand)
		{
			await _updateCarCommandHandler.Handle(updateCarCommand);
			return Ok("Araba Başarıyla Güncellenmiştir");
		}

		[HttpGet("GetCarWithBrand")]
		public async Task<IActionResult> GetCarWithBrand()
		{
			return Ok(_getCarWithBrandQueryHandler.Handle());
		}

        [HttpGet("Get5CarWithBrand")]
        public async Task<IActionResult> Get5CarWithBrand()
        {
            return Ok(_getLast5CarsWithBrandQueryHandler.Handle());
        }

		[HttpGet("GetCarByIdBrand/{id}")]
		public async Task<IActionResult> GetCarByIdBrand(int id)
		{
			return Ok(await _getCarByIdBarndQueryHandler.Handle(new GetCarByIdBrandQuery(id)));
		}
	}
}
