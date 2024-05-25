using CarBook.Application.Features.Editör.Commands.LocationCommands;
using CarBook.Application.Features.Editör.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Authorize(Roles = "Admin")]
	[Route("api/[controller]")]
	[ApiController]
	public class LocationController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LocationController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> LocationList()
		{
			var values = await _mediator.Send(new GetLocationQuery());
			return Ok(values);
		}

		[HttpGet("{LocationId}")]
		public async Task<IActionResult> GetLocation(int LocationId)
		{
			var value = await _mediator.Send(new GetLocationByIdQuery(LocationId));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateLocation(CreateLocationCommand createLocationCommand)
		{
			await _mediator.Send(createLocationCommand);
			return Ok("Lokasyon Başarıyla Eklenmiştir");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveLocation(int LocationId)
		{
			await _mediator.Send(new RemoveLocationCommand(LocationId));
			return Ok("Lokasyon Başarıyla Silinmiştir");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateLocation(UpdateLocationCommand updateLocationCommand)
		{
			await _mediator.Send(updateLocationCommand);
			return Ok("Lokasyon Başarıyla Güncellenmiştir");
		}
	}
}
