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
	public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
	{

		private readonly IRepository<Pricing> _pricingrepository;

		public GetPricingByIdQueryHandler(IRepository<Pricing> pricingrepository)
		{
			_pricingrepository = pricingrepository;
		}

		public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _pricingrepository.GetByIdAsync(request.Id);
			return new GetPricingByIdQueryResult
			{
				PricingId = value.PricingId,
				Name = value.Name
			};
		}
	}
}
