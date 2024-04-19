using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _mediator.Send(new GetTestimonialQuery());
            return Ok(values);
        }

        [HttpGet("{TestimonialId}")]
        public async Task<IActionResult> GetTestimonial(int TestimonialId)
        {
            var value = await _mediator.Send(new GetTestimonialByIdQuery(TestimonialId));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand createTestimonialCommand)
        {
            await _mediator.Send(createTestimonialCommand);
            return Ok("Referans Başarıyla Eklenmiştir");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTestimonial(int TestimonialId)
        {
            await _mediator.Send(new RemoveTestimonialCommand(TestimonialId));
            return Ok("Referans Başarıyla Silinmiştir");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand updateTestimonialCommand)
        {
            await _mediator.Send(updateTestimonialCommand);
            return Ok("Referans Başarıyla Güncellenmiştir");
        }
    }
}
