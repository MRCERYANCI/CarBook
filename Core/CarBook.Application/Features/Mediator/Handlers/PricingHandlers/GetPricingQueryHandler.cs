using CarBook.Application.Features.Editör.Queries.PricingQueries;
using CarBook.Application.Features.Editör.Results.PricingResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Editör.Handlers.PricingHandlers
{
	public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
	{
		private readonly IRepository<Pricing> _pricingrepository;

		public GetPricingQueryHandler(IRepository<Pricing> pricingrepository)
		{
			_pricingrepository = pricingrepository;
		}

		public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
		{
			var values = await _pricingrepository.GetAllAsync();
			return values.Select(x => new GetPricingQueryResult
			{
				PricingId = x.PricingId,
				Name = x.Name
			}).ToList();
		}
	}
}
