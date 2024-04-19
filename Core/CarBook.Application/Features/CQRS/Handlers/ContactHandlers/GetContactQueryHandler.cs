using CarBook.Application.Features.CQRS.Results.CategoryResults;
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
	public class GetContactQueryHandler
	{
		private readonly IRepository<Contact> _contactrepository;

		public GetContactQueryHandler(IRepository<Contact> contactrepository)
		{
			_contactrepository = contactrepository;
		}
		public async Task<List<GetContactQueryResult>> Handle()
		{
			var values = await _contactrepository.GetAllAsync();
			return values.Select(x => new GetContactQueryResult
			{
				ContactId = x.ContactId,
				Name = x.Name,
				Email = x.Email,
				Subject = x.Subject,
				Message = x.Message,
				SendDate = x.SendDate
			}).ToList();
		}
	}
}
