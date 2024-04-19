using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
	public class GetAboutByIdQueryHandler
	{
		private readonly IRepository<About> _aboutRepository;

		public GetAboutByIdQueryHandler(IRepository<About> aboutRepository)
		{
			_aboutRepository = aboutRepository;
		}

		public async Task<GetAboutQueryResult> Handle(GetAboutByIdQuery getAboutByIdQuery)
		{
			var values = await _aboutRepository.GetByIdAsync(getAboutByIdQuery.Id);

			return new GetAboutQueryResult
			{
				AboutId = values.AboutId,
				Description = values.Description,
				Title = values.Title,
				ImageUrl = values.ImageUrl
			};

		}
	}
}
