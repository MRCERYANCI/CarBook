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
	public class UpdateCategoryCommandHandler
	{
		private readonly IRepository<Category> _categoryrepository;

		public UpdateCategoryCommandHandler(IRepository<Category> categoryrepository)
		{
			_categoryrepository = categoryrepository;
		}

		public async Task Handle(UpdateCategoryCommand updateCategoryCommand)
		{
			var value = await _categoryrepository.GetByIdAsync(updateCategoryCommand.CategoryId);
			if (value != null)
			{
				value.Status = updateCategoryCommand.Status;
				value.Name = updateCategoryCommand.Name;

				await _categoryrepository.UpdateAsync(value);
			}
		}
	}
}
