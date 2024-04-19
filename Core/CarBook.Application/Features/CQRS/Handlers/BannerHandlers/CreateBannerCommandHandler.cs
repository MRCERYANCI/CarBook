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
	public class CreateBannerCommandHandler
	{
		private readonly IRepository<Banner> _bannerrepository;

		public CreateBannerCommandHandler(IRepository<Banner> bannerrepository)
		{
			_bannerrepository = bannerrepository;
		}

		public async Task Handle(CreateBannerCommand command)
		{
			await _bannerrepository.CreateAsync(new Banner
			{
				Description = command.Description,
				Title = command.Title,
				VideoDescription = command.VideoDescription,
				VideoUrl = command.VideoUrl
			});
		}
	}
}
