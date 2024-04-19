using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly CreateContactCommandHandler _createContactCommandHandler;
		private readonly UpdateContactCommandHandler _updateContactCommandHandler;
		private readonly RemoveContactCommandHandler _removeContactCommandHandler;
		private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
		private readonly GetContactQueryHandler _getContactQueryHandler;

		public ContactController(CreateContactCommandHandler createContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler)
		{
			_createContactCommandHandler = createContactCommandHandler;
			_updateContactCommandHandler = updateContactCommandHandler;
			_removeContactCommandHandler = removeContactCommandHandler;
			_getContactByIdQueryHandler = getContactByIdQueryHandler;
			_getContactQueryHandler = getContactQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> ContactList()
		{
			var values = await _getContactQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{ContactId}")]
		public async Task<IActionResult> GetContact(int ContactId)
		{
			var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(ContactId));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactCommand createContactCommand)
		{
			await _createContactCommandHandler.Handle(createContactCommand);
			return Ok("İletişim Bilgisi Başarıyla Eklenmiştir");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveContact(int ContactId)
		{
			await _removeContactCommandHandler.Handle(new RemoveContactCommand(ContactId));
			return Ok("İletişim Başarıyla Silinmiştir");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateContact(UpdateContactCommand updateContactCommand)
		{
			await _updateContactCommandHandler.Handle(updateContactCommand);
			return Ok("İletişim Başarıyla Güncellenmiştir");
		}
	}
}
