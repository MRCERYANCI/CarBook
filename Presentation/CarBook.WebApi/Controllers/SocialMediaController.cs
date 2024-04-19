using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediaController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SocialMediaController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> SocialMediaList()
		{
			var values = await _mediator.Send(new GetSocialMediaQuery());
			return Ok(values);
		}

		[HttpGet("{SocialMediaId}")]
		public async Task<IActionResult> GetSocialMedia(int SocialMediaId)
		{
			var value = await _mediator.Send(new GetSocialMediaByIdQuery(SocialMediaId));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand createSocialMediaCommand)
		{
			await _mediator.Send(createSocialMediaCommand);
			return Ok("Sosyal Medya Başarıyla Eklenmiştir");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveSocialMedia(int SocialMediaId)
		{
			await _mediator.Send(new RemoveSocialMediaCommand(SocialMediaId));
			return Ok("Sosyal Medya Başarıyla Silinmiştir");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand updateSocialMediaCommand)
		{
			await _mediator.Send(updateSocialMediaCommand);
			return Ok("Sosyal Medya Başarıyla Güncellenmiştir");
		}
	}
}
