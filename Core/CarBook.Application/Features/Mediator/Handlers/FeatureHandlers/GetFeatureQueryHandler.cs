using CarBook.Application.Features.CQRS.Results.BannerResults;
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
	public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>> //GetFeatureQuery İstek Yapılacak Ordan Yanıt Olarak GetFeatureQueryResult geriye dönecek
	{
		private readonly IRepository<Feature> _featurerepository;

		public GetFeatureQueryHandler(IRepository<Feature> featurerepository)
		{
			_featurerepository = featurerepository;
		}

		public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
		{
			var values = await _featurerepository.GetAllAsync();
			return values.Select(x => new GetFeatureQueryResult
			{
				FeatureId = x.FeatureId,
				Name = x.Name
			}).ToList();
		}
	}
}
