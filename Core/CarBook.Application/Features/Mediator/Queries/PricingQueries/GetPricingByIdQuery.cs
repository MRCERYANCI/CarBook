using CarBook.Application.Features.Editör.Results.PricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Editör.Queries.PricingQueries
{
	public class GetPricingByIdQuery : IRequest<GetPricingByIdQueryResult>
	{
        public int Id { get; set; }

		public GetPricingByIdQuery(int id)
		{
			Id = id;
		}
	}
}
