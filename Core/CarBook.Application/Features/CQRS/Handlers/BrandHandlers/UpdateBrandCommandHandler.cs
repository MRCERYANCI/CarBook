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
	public class UpdateBrandCommandHandler
	{
		private readonly IRepository<Brand> _brandrepository;

		public UpdateBrandCommandHandler(IRepository<Brand> brandrepository)
		{
			_brandrepository = brandrepository;
		}

		public async Task Handle(UpdateBrandCommand updateBrandCommand)
		{
			var values = await _brandrepository.GetByIdAsync(updateBrandCommand.BrandId);

			if (values != null)
			{
				values.Name = updateBrandCommand.Name;

				await _brandrepository.UpdateAsync(values);
			}
		}
	}
}
