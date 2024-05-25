using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Validators.ReviewValidators;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewByCarId(int id)
        {
            return Ok(await _mediator.Send(new GetReviewByCarIdQuery(id)));
        }

        [HttpPost] 
        public async Task<IActionResult> CreateReview(CreateReviewCommand createReviewCommand)
        {
            CreateReviewValidator validationRules = new CreateReviewValidator();
            var validationResult = validationRules.Validate(createReviewCommand);

            if (validationResult.IsValid)
            {
                await _mediator.Send(createReviewCommand);
                return Ok("Yorumunuz Başarıyla Eklenmiştir");
            }
            else
                return BadRequest(validationResult);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand updateReviewCommand)
        {
            await _mediator.Send(updateReviewCommand);
            return Ok("Yorumunuz Başarıyla Güncellenmiştir");
        }

        [HttpGet("GetReviewByCar/{id}")]
        public async Task<IActionResult> GetReviewByCar(int id)
        {
            return Ok(await _mediator.Send(new GetReviewByCarQuery(id)));
        }
    }
}
