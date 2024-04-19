using CarBook.Application.Features.CQRS.Results.BrandResults;
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
	public class GetCategoryQueryHandler
	{
		private readonly IRepository<Category> _categoryrepository;

		public GetCategoryQueryHandler(IRepository<Category> categoryrepository)
		{
			_categoryrepository = categoryrepository;
		}
		public async Task<List<GetCategoryQueryResult>> Handle()
		{
			var values = await _categoryrepository.GetAllAsync();
			return values.Select(x => new GetCategoryQueryResult
			{
				CategoryId = x.CategoryId,
				Name = x.Name,
				Status = x.Status
			}).ToList();
		}
	}
}
