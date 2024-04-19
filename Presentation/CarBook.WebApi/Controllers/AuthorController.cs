using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AuthorController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> AuthorList()
		{
			var values = await _mediator.Send(new GetAuthorQuery());
			return Ok(values);
		}

		[HttpGet("{AuthorId}")]
		public async Task<IActionResult> GetAuthor(int AuthorId)
		{
			var value = await _mediator.Send(new GetAuthorByIdQuery(AuthorId));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateAuthor(CreateAuthorCommand createAuthorCommand)
		{
			await _mediator.Send(createAuthorCommand);
			return Ok("Yazar Başarıyla Eklenmiştir");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveAuthor(int AuthorId)
		{
			await _mediator.Send(new RemoveAuthorCommand(AuthorId));
			return Ok("Yazar Başarıyla Silinmiştir");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand updateAuthorCommand)
		{
			await _mediator.Send(updateAuthorCommand);
			return Ok("Yazar Başarıyla Güncellenmiştir");
		}
	}
}
