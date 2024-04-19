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
	public class CreateBrandCommandHandler
	{
		private readonly IRepository<Brand> _brandrepository;

		public CreateBrandCommandHandler(IRepository<Brand> brandrepository)
		{
			_brandrepository = brandrepository;
		}

		public async Task Handle(CreateBrandCommand command)
		{
			await _brandrepository.CreateAsync(new Brand
			{
				Name = command.Name
			});
		}
	}
}
