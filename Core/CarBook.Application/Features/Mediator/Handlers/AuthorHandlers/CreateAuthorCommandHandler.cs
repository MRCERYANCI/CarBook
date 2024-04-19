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
	public class CreateAuthorCommandHandler:IRequestHandler<CreateAuthorCommand>
	{
		private readonly IRepository<Author> _authorrepository;

		public CreateAuthorCommandHandler(IRepository<Author> authorrepository)
		{
			_authorrepository = authorrepository;
		}

		public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
		{
			if(request != null)
			{
				await _authorrepository.CreateAsync(new Author
				{
					Name = request.Name,
					CreateDate = request.CreateDate,
					ImageUrl = request.ImageUrl,
					Status = request.Status,
					Description = request.Description
				});
			}
		}
	}
}
