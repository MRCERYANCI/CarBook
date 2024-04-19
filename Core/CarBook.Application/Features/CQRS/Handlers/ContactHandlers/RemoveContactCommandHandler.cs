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
	public class RemoveContactCommandHandler
	{
		private readonly IRepository<Contact> _contactrepository;

		public RemoveContactCommandHandler(IRepository<Contact> contactrepository)
		{
			_contactrepository = contactrepository;
		}

		public async Task Handle(RemoveContactCommand command)
		{
			if (command != null)
			{
				var value = await _contactrepository.GetByIdAsync(command.Id);
				if (value != null)
				{			
					await _contactrepository.RemoveAsync(value);
				}
			}
		}
	}
}
