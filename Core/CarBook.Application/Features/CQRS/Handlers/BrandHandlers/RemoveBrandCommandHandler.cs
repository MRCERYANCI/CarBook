using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
	public class RemoveBrandCommandHandler
	{
		private readonly IRepository<Brand> _brandrepository;

		public RemoveBrandCommandHandler(IRepository<Brand> brandrepository)
		{
			_brandrepository = brandrepository;
		}

		public async Task Handle(RemoveBrandCommand removeBrandCommand)
		{
			var values = await _brandrepository.GetByIdAsync(removeBrandCommand.Id);
			await _brandrepository.RemoveAsync(values);
		}
	}
}
