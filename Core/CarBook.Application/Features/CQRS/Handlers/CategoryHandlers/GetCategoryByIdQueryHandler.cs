using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class GetCategoryByIdQueryHandler
	{
		private readonly IRepository<Category> _categoryrepository;

		public GetCategoryByIdQueryHandler(IRepository<Category> categoryrepository)
		{
			_categoryrepository = categoryrepository;
		}
		public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery getCategoryByIdQuery)
		{
			var values = await _categoryrepository.GetByIdAsync(getCategoryByIdQuery.Id);
			return new GetCategoryByIdQueryResult
			{
				CategoryId = values.CategoryId,
				Name = values.Name,
				Status = values.Status
			};
		}
	}
}
