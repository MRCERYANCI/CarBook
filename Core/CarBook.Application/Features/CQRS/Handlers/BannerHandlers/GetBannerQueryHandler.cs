using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
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
	public class GetBannerQueryHandler
	{
		private readonly IRepository<Banner> _bannerrepository;

		public GetBannerQueryHandler(IRepository<Banner> bannerrepository)
		{
			_bannerrepository = bannerrepository;
		}

		public async Task<List<GetBannerQueryResult>> Handle()
		{
			var values =  await _bannerrepository.GetAllAsync();
			return values.Select(x => new GetBannerQueryResult
			{
				BannerId = x.BannerId,
				Title = x.Title,
				Description = x.Description,
				VideoDescription = x.VideoDescription,
				VideoUrl = x.VideoUrl
			}).ToList();
		}
	}
}
