using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Handlers.BlogHandlers;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogController : ControllerBase
	{
		private readonly IMediator _mediator;

		public BlogController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> BlogList()
		{
			var values = await _mediator.Send(new GetBlogQuery());
			return Ok(values);
		}

		[HttpGet("{BlogId}")]
		public async Task<IActionResult> GetBlog(int BlogId)
		{
			var value = await _mediator.Send(new GetBlogByIdQuery(BlogId));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBlog(CreateBlogCommand createBlogCommand)
		{
			await _mediator.Send(createBlogCommand);
			return Ok("Blog Başarıyla Eklenmiştir");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveBlog(int BlogId)
		{
			await _mediator.Send(new RemoveBlogCommand(BlogId));
			return Ok("Blog Başarıyla Silinmiştir");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateBlog(UpdateBlogCommand updateBlogCommand)
		{
			await _mediator.Send(updateBlogCommand);
			return Ok("Blog Başarıyla Güncellenmiştir");
		}

		[HttpGet("GetLast3BlogsWithAuthors")]
		public async Task<IActionResult> GetLast3BlogsWithAuthorsQueryHandler()
		{
			var values = await _mediator.Send(new GetLast3BlogsWithAuthorsQuery());
			return Ok(values);
		}

        [HttpGet("GetLastBlogsWithAuthors")]
        public async Task<IActionResult> GetLastBlogsWithAuthors()
        {
            var values = await _mediator.Send(new GetAllBlogsWithAuthorQuery());
            return Ok(values);
        }
    }
}

