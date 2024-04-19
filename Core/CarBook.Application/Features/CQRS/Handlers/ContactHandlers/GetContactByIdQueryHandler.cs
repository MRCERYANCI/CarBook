using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class GetContactByIdQueryHandler
	{
		private readonly IRepository<Contact> _contactrepository;

		public GetContactByIdQueryHandler(IRepository<Contact> contactrepository)
		{
			_contactrepository = contactrepository;
		}
		public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery getContactByIdQuery)
		{
			var values = await _contactrepository.GetByIdAsync(getContactByIdQuery.Id);

			return new GetContactByIdQueryResult
			{
				ContactId = values.ContactId,
				Name = values.Name,
				Email = values.Email,
				Subject = values.Subject,
				Message = values.Message,
				SendDate = values.SendDate
			};
		}
	}
}
