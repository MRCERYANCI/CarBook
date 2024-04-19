using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
	{
		private IRepository<Blog> _repositoryblog;

		public GetBlogQueryHandler(IRepository<Blog> repositoryblog)
		{
			_repositoryblog = repositoryblog;
		}

		public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
		{
			var values = await _repositoryblog.GetAllAsync();

			return values.Select(x => new GetBlogQueryResult
			{
				BlogId = x.BlogId,
				AuthorId = x.AuthorId,
				CategoryId = x.CategoryId,
				Title = x.Title,
				CoverImageUrl = x.CoverImageUrl,
				CreatedDate = x.CreatedDate
			}).ToList();
		}
	}
}
