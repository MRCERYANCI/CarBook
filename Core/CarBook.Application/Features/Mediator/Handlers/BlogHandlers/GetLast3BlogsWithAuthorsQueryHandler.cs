using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetLast3BlogsWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorsQuery, List<GetLast3BlogsWithAuthorsQueryResult>>
	{
		private readonly IBlogRepository _blogRepository;

		public GetLast3BlogsWithAuthorsQueryHandler(IBlogRepository blogRepository)
		{
			_blogRepository = blogRepository;
		}

		public async Task<List<GetLast3BlogsWithAuthorsQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
		{
			var values = _blogRepository.GetLast3BlogsWithAuthors();

			return values.Select(x => new GetLast3BlogsWithAuthorsQueryResult
			{
				BlogId = x.BlogId,
				Title = x.Title,
				Name = x.Author.Name,
				CoverImageUrl = x.CoverImageUrl,
				CategoryId = x.CategoryId,
				CreatedDate = x.CreatedDate
			}).ToList();
		}
	}
}
