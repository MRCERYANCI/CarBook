using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class CreateCategoryCommandHandler
	{
		private readonly IRepository<Category> _categoryrepository;

		public CreateCategoryCommandHandler(IRepository<Category> categoryrepository)
		{
			_categoryrepository = categoryrepository;
		}

		public async Task Handle(CreateCategoryCommand command)
		{
			await _categoryrepository.CreateAsync(new Category
			{
				Name = command.Name,
				Status = command.Status
			});
		}
	}
}
