using CarBook.Application.Features.Editör.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServiceController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ServiceController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> ServiceList()
		{
			var values = await _mediator.Send(new GetServiceQuery());
			return Ok(values);
		}

		[HttpGet("{ServiceId}")]
		public async Task<IActionResult> GetService(int ServiceId)
		{
			var value = await _mediator.Send(new GetServiceByIdQuery(ServiceId));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateService(CreateServiceCommand createServiceCommand)
		{
			await _mediator.Send(createServiceCommand);
			return Ok("Hizmetler Başarıyla Eklenmiştir");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveService(int ServiceId)
		{
			await _mediator.Send(new RemoveServiceCommand(ServiceId));
			return Ok("Hizmetler Başarıyla Silinmiştir");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateService(UpdateServiceCommand updateServiceCommand)
		{
			await _mediator.Send(updateServiceCommand);
			return Ok("Hizmetler Başarıyla Güncellenmiştir");
		}
	}
}
