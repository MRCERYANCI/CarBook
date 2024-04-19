using CarBook.Application.Features.Editör.Commands.PricingCommands;
using CarBook.Application.Features.Editör.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PricingController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PricingController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> PricingList()
		{
			var values = await _mediator.Send(new GetPricingQuery());
			return Ok(values);
		}

		[HttpGet("{PricingId}")]
		public async Task<IActionResult> GetPricing(int PricingId)
		{
			var value = await _mediator.Send(new GetPricingByIdQuery(PricingId));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreatePricing(CreatePricingCommand createPricingCommand)
		{
			await _mediator.Send(createPricingCommand);
			return Ok("Fiyat Başarıyla Eklenmiştir");
		}

		[HttpDelete]
		public async Task<IActionResult> RemovePricing(int PricingId)
		{
			await _mediator.Send(new RemovePricingCommand(PricingId));
			return Ok("Fiyat Başarıyla Silinmiştir");
		}

		[HttpPut]
		public async Task<IActionResult> UpdatePricing(UpdatePricingCommand updatePricingCommand)
		{
			await _mediator.Send(updatePricingCommand);
			return Ok("Fiyat Başarıyla Güncellenmiştir");
		}
	}
}
