using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
	public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
	{
		private readonly IRepository<Author> _authorrepository;

		public GetAuthorQueryHandler(IRepository<Author> authorrepository)
		{
			_authorrepository = authorrepository;
		}

		public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
		{
			var values = await _authorrepository.GetAllAsync();

			return values.Select(x => new GetAuthorQueryResult
			{
				AuthorId = x.AuthorId,
				Name = x.Name,
				CreateDate = DateTime.Now,
				Description = x.Description,
				ImageUrl = x.ImageUrl,
				Status = x.Status
			}).ToList();
		}
	}
}
