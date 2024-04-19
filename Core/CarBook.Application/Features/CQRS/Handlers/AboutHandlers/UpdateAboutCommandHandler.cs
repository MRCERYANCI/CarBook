using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
	public class UpdateAboutCommandHandler
	{
		private readonly IRepository<About> _aboutRepository;

		public UpdateAboutCommandHandler(IRepository<About> aboutRepository)
		{
			_aboutRepository = aboutRepository;
		}

		public async Task Handle(UpdateAboutCommand updateAboutCommand)
		{
			var values = await _aboutRepository.GetByIdAsync(updateAboutCommand.AboutId);

			values.Description = updateAboutCommand.Description;
			values.Title = updateAboutCommand.Title;
			values.ImageUrl = updateAboutCommand.ImageUrl;

			await _aboutRepository.UpdateAsync(values);
		}
	}
}
