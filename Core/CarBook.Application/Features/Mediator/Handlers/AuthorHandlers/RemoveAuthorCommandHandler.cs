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
	public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
	{
		private readonly IRepository<Author> _authorrepository;

		public RemoveAuthorCommandHandler(IRepository<Author> authorrepository)
		{
			_authorrepository = authorrepository;
		}

		public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
		{
			var value = await _authorrepository.GetByIdAsync(request.Id);
			if (value != null)
			{
				await _authorrepository.RemoveAsync(value);
			}
		}
	}
}
