using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandController : ControllerBase
	{
		private readonly CreateBrandCommandHandler _createBrandCommandHandler;
		private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
		private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
		private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
		private readonly GetBrandQueryHandler _getBrandQueryHandler;

		public BrandController(CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler)
		{
			_createBrandCommandHandler = createBrandCommandHandler;
			_updateBrandCommandHandler = updateBrandCommandHandler;
			_removeBrandCommandHandler = removeBrandCommandHandler;
			_getBrandByIdQueryHandler = getBrandByIdQueryHandler;
			_getBrandQueryHandler = getBrandQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> BrandList()
		{
			var values = await _getBrandQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{BrandId}")]
		public async Task<IActionResult> GetBrand(int BrandId)
		{
			var value = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(BrandId));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBrand(CreateBrandCommand createBrandCommand)
		{
			await _createBrandCommandHandler.Handle(createBrandCommand);
			return Ok("Markalar Bilgisi Başarıyla Eklenmiştir");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveBrand(int BrandId)
		{
			await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(BrandId));
			return Ok("Markalar Başarıyla Silinmiştir");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateBrand(UpdateBrandCommand updateBrandCommand)
		{
			await _updateBrandCommandHandler.Handle(updateBrandCommand);
			return Ok("Markalar Başarıyla Güncellenmiştir");
		}
	}
}
