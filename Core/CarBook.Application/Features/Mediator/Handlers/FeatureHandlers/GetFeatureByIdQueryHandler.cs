using CarBook.Application.Features.Editör.Queries.FeatureQueries;
using CarBook.Application.Features.Editör.Results.FeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Editör.Handlers.FeatureHandlers
{
	public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
	{
		private readonly IRepository<Feature> _featurerepository;

		public GetFeatureByIdQueryHandler(IRepository<Feature> featurerepository)
		{
			_featurerepository = featurerepository;
		}

		public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _featurerepository.GetByIdAsync(request.Id);
			return new GetFeatureByIdQueryResult
			{
				FeatureId = value.FeatureId,
				Name = value.Name
			};
		}
	}
}
