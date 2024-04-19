using CarBook.Application.Features.CQRS.Queries.BrandQueries;
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
	public class GetBrandByIdQueryHandler
	{
		private readonly IRepository<Brand> _brandrepository;

		public GetBrandByIdQueryHandler(IRepository<Brand> brandrepository)
		{
			_brandrepository = brandrepository;
		}
		public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery getBrandByIdQuery)
		{
			var values = await _brandrepository.GetByIdAsync(getBrandByIdQuery.Id);
			return new GetBrandByIdQueryResult
			{
				BrandId = values.BrandId,
				Name = values.Name
			};

		}
	}
}
