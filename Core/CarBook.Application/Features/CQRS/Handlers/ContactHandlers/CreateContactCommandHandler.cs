using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class CreateContactCommandHandler
	{
		private readonly IRepository<Contact> _contactrepository;

		public CreateContactCommandHandler(IRepository<Contact> contactrepository)
		{
			_contactrepository = contactrepository;
		}

		public async Task Handle(CreateContactCommand command)
		{
			if(command != null)
			{
				await _contactrepository.CreateAsync(new Contact
				{
					Name = command.Name,
					Email = command.Email,
					Subject = command.Subject,
					Message = command.Message,
					SendDate = command.SendDate
				});
			}
		}
	}
}
