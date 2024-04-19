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
	public class RemoveCategoryCommandHandler
	{
		private readonly IRepository<Category> _categoryrepository;

		public RemoveCategoryCommandHandler(IRepository<Category> categoryrepository)
		{
			_categoryrepository = categoryrepository;
		}

		public async Task Handle(RemoveCategoryCommand removeCategoryCommand)
		{
			var value = await _categoryrepository.GetByIdAsync(removeCategoryCommand.Id);
			if (value != null)
			{
				await _categoryrepository.RemoveAsync(value);
			}
		}
	}
}
