using CarBook.Application.Features.Editör.Commands.FooterAddressCommands;
using CarBook.Application.Features.Editör.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FooterAddressController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FooterAddressController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> FooterAddressList()
		{
			var values = await _mediator.Send(new GetFooterAddressQuery());
			return Ok(values);
		}

		[HttpGet("{FooterAddressId}")]
		public async Task<IActionResult> GetFooterAddress(int FooterAddressId)
		{
			var value = await _mediator.Send(new GetFooterAddressByIdQuery(FooterAddressId));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand createFooterAddressCommand)
		{
			await _mediator.Send(createFooterAddressCommand);
			return Ok("Footer Adresi Başarıyla Eklenmiştir");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveFooterAddress(int FooterAddressId)
		{
			await _mediator.Send(new RemoveFooterAddressCommand(FooterAddressId));
			return Ok("Footer Adresi Başarıyla Silinmiştir");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand updateFooterAddressCommand)
		{
			await _mediator.Send(updateFooterAddressCommand);
			return Ok("Footer Adresi Başarıyla Güncellenmiştir");
		}
	}
}
