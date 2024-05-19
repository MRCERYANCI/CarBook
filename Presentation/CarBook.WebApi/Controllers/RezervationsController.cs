using CarBook.Application.Features.Mediator.Commands.RezervationCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RezervationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateRezervationCommand createRezervationCommand)
        {
            await _mediator.Send(createRezervationCommand);
            return Ok("Rezervasyonunuz Başarıyla Alınmıştır");
        }
    }
}
