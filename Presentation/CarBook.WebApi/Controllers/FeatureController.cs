using CarBook.Application.Features.Editör.Commands.FeatureCommands;
using CarBook.Application.Features.Editör.Handlers.FeatureHandlers;
using CarBook.Application.Features.Editör.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FeatureController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> FeatureList()
		{
			var values = await _mediator.Send(new GetFeatureQuery());
			return Ok(values);
		}

		[HttpGet("{FeatureId}")]
		public async Task<IActionResult> GetFeature(int FeatureId)
		{
			var value = await _mediator.Send(new GetFeatureByIdQuery(FeatureId));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureCommand createFeatureCommand)
		{
			await _mediator.Send(createFeatureCommand);
			return Ok("Özellik Başarıyla Eklenmiştir");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveFeature(int FeatureId)
		{
		    await _mediator.Send(new RemoveFeatureCommand(FeatureId));
			return Ok("Özellik Başarıyla Silinmiştir");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand updateFeatureCommand)
		{
			await _mediator.Send(updateFeatureCommand);
			return Ok("Özellik Başarıyla Güncellenmiştir");
		}
	}
}
