using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutController : ControllerBase
	{
		private readonly CreateAboutCommandHandler _createAboutCommandHandler;
		private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
		private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;
		private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
		private readonly GetAboutQueryHandler _getAboutQueryHandler;

		public AboutController(CreateAboutCommandHandler createAboutCommandHandler, UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler)
		{
			_createAboutCommandHandler = createAboutCommandHandler;
			_updateAboutCommandHandler = updateAboutCommandHandler;
			_removeAboutCommandHandler = removeAboutCommandHandler;
			_getAboutByIdQueryHandler = getAboutByIdQueryHandler;
			_getAboutQueryHandler = getAboutQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> AboutList()
		{
			var values = await _getAboutQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{AboutId}")]
		public async Task<IActionResult> GetAbout(int AboutId)
		{
			var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(AboutId));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateAbout(CreateAboutCommand createAboutCommand)
		{
		    await _createAboutCommandHandler.Handle(createAboutCommand);
			return Ok("Hakkımda Bilgisi Başarıyla Eklenmiştir");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveAbout(int AboutId)
		{
			await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(AboutId));
			return Ok("Hakkımda Başarıyla Silinmiştir");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAbout(UpdateAboutCommand updateAboutCommand)
		{
			await _updateAboutCommandHandler.Handle(updateAboutCommand);
			return Ok("Hakkımda Başarıyla Güncellenmiştir");
		}
	}
}
