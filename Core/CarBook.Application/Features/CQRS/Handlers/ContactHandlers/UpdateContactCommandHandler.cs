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
	public class UpdateContactCommandHandler
	{
		private readonly IRepository<Contact> _contactrepository;

		public UpdateContactCommandHandler(IRepository<Contact> contactrepository)
		{
			_contactrepository = contactrepository;
		}

		public async Task Handle(UpdateContactCommand command)
		{

			if (command != null)
			{
				var value = await _contactrepository.GetByIdAsync(command.ContactId);
				if(value != null)
				{
					value.Name = command.Name;
					value.Email = command.Email;
					value.SendDate = command.SendDate;
					value.Subject = command.Subject;
					value.Message = command.Message;

					await _contactrepository.UpdateAsync(value);
				}
			}
		}
	}
}
