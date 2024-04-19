using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
	public class GetBrandQueryHandler
	{
		private readonly IRepository<Brand> _brandrepository;

		public GetBrandQueryHandler(IRepository<Brand> brandrepository)
		{
			_brandrepository = brandrepository;
		}
		public async Task<List<GetBrandQueryResult>> Handle()
		{
			var values = await _brandrepository.GetAllAsync();
			return values.Select(x => new GetBrandQueryResult
			{
				BrandId = x.BrandId,
				Name = x.Name,
			}).ToList();
		}
	}
}
