using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BannerController : ControllerBase
	{
		private readonly CreateBannerCommandHandler _createBannerCommandHandler;
		private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
		private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
		private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
		private readonly GetBannerQueryHandler _getBannerQueryHandler;
		private readonly GetBannerFirstQueryHandler _getBannerQueryResultFirst;

        public BannerController(CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, GetBannerFirstQueryHandler getBannerQueryResultFirst)
        {
            _createBannerCommandHandler = createBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _getBannerQueryResultFirst = getBannerQueryResultFirst;
        }

        [HttpGet]
		public async Task<IActionResult> BannerList()
		{
			var values = await _getBannerQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{BannerId}")]
		public async Task<IActionResult> GetBanner(int BannerId)
		{
			var value = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(BannerId));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBanner(CreateBannerCommand createBannerCommand)
		{
			await _createBannerCommandHandler.Handle(createBannerCommand);
			return Ok("Banner Bilgisi Başarıyla Eklenmiştir");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveBanner(int BannerId)
		{
			await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(BannerId));
			return Ok("Banner Başarıyla Silinmiştir");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateBanner(UpdateBannerCommand updateBannerCommand)
		{
			await _updateBannerCommandHandler.Handle(updateBannerCommand);
			return Ok("Banner Başarıyla Güncellenmiştir");
		}

        [HttpGet("BannerFirstOrDefault")]
        public async Task<IActionResult> BannerFirstOrDefault()
        {
			var values = await _getBannerQueryResultFirst.Handle();
            return Ok(values);
        }
    }
}
