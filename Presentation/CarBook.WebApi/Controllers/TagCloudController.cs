using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TagCloudList()
        {
            var values = await _mediator.Send(new GetTagCloudQuery());
            return Ok(values);
        }

        [HttpGet("{TagCloudId}")]
        public async Task<IActionResult> GetTagCloud(int TagCloudId)
        {
            var value = await _mediator.Send(new GetTagCloudByIdQuery(TagCloudId));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand createTagCloudCommand)
        {
            await _mediator.Send(createTagCloudCommand);
            return Ok("TagCloud Başarıyla Eklenmiştir");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTagCloud(int TagCloudId)
        {
            await _mediator.Send(new RemoveTagCloudCommand(TagCloudId));
            return Ok("TagCloud Başarıyla Silinmiştir");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand updateTagCloudCommand)
        {
            await _mediator.Send(updateTagCloudCommand);
            return Ok("TagCloud Başarıyla Güncellenmiştir");
        }

        [HttpGet("GetTagCloudBlogById")]
        public async Task<IActionResult> GetTagCloudBlogById(int BlogId)
        {
            var values = await _mediator.Send(new GetTagCloudBlogByIdQuery(BlogId));
            return Ok(values);
        }
    }
}
