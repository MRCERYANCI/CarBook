using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
	public class GetBannerByIdQueryHandler
	{
		private readonly IRepository<Banner> _bannerrepository;

		public GetBannerByIdQueryHandler(IRepository<Banner> bannerrepository)
		{
			_bannerrepository = bannerrepository;
		}

		public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery getBannerByIdQuery)
		{
			var values = await _bannerrepository.GetByIdAsync(getBannerByIdQuery.Id);
			return new GetBannerByIdQueryResult
			{
				BannerId = values.BannerId,
				Description = values.Description,
				Title = values.Title,
				VideoDescription = values.VideoDescription,
				VideoUrl = values.VideoUrl
			};
		}
	}
}
