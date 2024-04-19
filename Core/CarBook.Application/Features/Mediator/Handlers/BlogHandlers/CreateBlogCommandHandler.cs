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
	public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
	{
		private IRepository<Blog> _repositoryblog;

		public CreateBlogCommandHandler(IRepository<Blog> repositoryblog)
		{
			_repositoryblog = repositoryblog;
		}

		public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
		{
			await _repositoryblog.CreateAsync(new Blog
			{
				AuthorId = request.AuthorId,
				CategoryId = request.CategoryId,
				Title = request.Title,
				CoverImageUrl = request.CoverImageUrl,
				CreatedDate = request.CreatedDate,
			});
		}
	}
}
