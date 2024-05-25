using CarBook.Application.Features.Mediator.Commands.AppUserCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SignUpsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateAppUserCommand createAppUserCommand)
        {
            await _mediator.Send(createAppUserCommand);
            return Ok("Kayıt Başarıyla Oluşturlumuştur");
        }
    }
}
