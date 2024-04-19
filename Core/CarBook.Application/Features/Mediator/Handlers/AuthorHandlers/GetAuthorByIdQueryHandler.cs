using CarBook.Application.Features.CQRS.Results.AboutResults;
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
	public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
	{
		private readonly IRepository<Author> _authorrepository;

		public GetAuthorByIdQueryHandler(IRepository<Author> authorrepository)
		{
			_authorrepository = authorrepository;
		}


		public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _authorrepository.GetByIdAsync(request.Id);

			return new GetAuthorByIdQueryResult
			{
				AuthorId = value.AuthorId,
				Name = value.Name,
				CreateDate = DateTime.Now,
				Description = value.Description,
				ImageUrl = value.ImageUrl,
				Status = value.Status
			};
		}
	}
}
