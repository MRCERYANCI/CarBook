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
	public class RemoveBannerCommandHandler
	{
		private readonly IRepository<Banner> _bannerrepository;

		public RemoveBannerCommandHandler(IRepository<Banner> bannerrepository)
		{
			_bannerrepository = bannerrepository;
		}

		public async Task Handle(RemoveBannerCommand removeBannerCommand)
		{
			var values = await _bannerrepository.GetByIdAsync(removeBannerCommand.Id);
			await _bannerrepository.RemoveAsync(values);
		}
	}
}
