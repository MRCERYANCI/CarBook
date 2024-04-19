using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
	public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
	{
		private readonly IRepository<Author> _authorrepository;

		public UpdateAuthorCommandHandler(IRepository<Author> authorrepository)
		{
			_authorrepository = authorrepository;
		}

		public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
		{
			var value = await _authorrepository.GetByIdAsync(request.AuthorId);

			if (value != null)
			{
				value.Name = request.Name;
				value.Status = request.Status;
				value.Description = request.Description;
				value.CreateDate = request.CreateDate;
				value.ImageUrl = request.ImageUrl;

				await _authorrepository.UpdateAsync(value);
			}
		}
	}
}
