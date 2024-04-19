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
	public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
	{
		private IRepository<Blog> _repositoryblog;

		public UpdateBlogCommandHandler(IRepository<Blog> repositoryblog)
		{
			_repositoryblog = repositoryblog;
		}

		public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
		{
			var value = await _repositoryblog.GetByIdAsync(request.BlogId);
			if (value != null)
			{
				value.Title = request.Title;
				value.CategoryId = request.CategoryId;
				value.AuthorId = request.AuthorId;
				value.CreatedDate = request.CreatedDate;
				value.CoverImageUrl	= request.CoverImageUrl;

				await _repositoryblog.UpdateAsync(value);
			}
		}
	}
}
