using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand>
	{
		private IRepository<Blog> _repositoryblog;

		public RemoveBlogCommandHandler(IRepository<Blog> repositoryblog)
		{
			_repositoryblog = repositoryblog;
		}


		public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
		{
			var value = await _repositoryblog.GetByIdAsync(request.Id);
			if (value != null)
			{
				await _repositoryblog.RemoveAsync(value);
			}
		}
	}
}
