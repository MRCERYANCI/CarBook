using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
	public class UpdateBannerCommandHandler
	{
		private readonly IRepository<Banner> _bannerrepository;

		public UpdateBannerCommandHandler(IRepository<Banner> bannerrepository)
		{
			_bannerrepository = bannerrepository;
		}

		public async Task Handle(UpdateBannerCommand updateBannerCommand)
		{
			var values = await _bannerrepository.GetByIdAsync(updateBannerCommand.BannerId);

			if (values != null)
			{
				values.Title = updateBannerCommand.Title;
				values.VideoUrl= updateBannerCommand.VideoUrl;
				values.Description = updateBannerCommand.Description;
				values.VideoDescription = updateBannerCommand.VideoDescription;

				await _bannerrepository.UpdateAsync(values);
			}

		}
	}
}
