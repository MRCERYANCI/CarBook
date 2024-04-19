using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
		private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
		private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
		private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
		private readonly GetCategoryQueryHandler _getCategoryQueryHandler;

		public CategoryController(CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler)
		{
			_createCategoryCommandHandler = createCategoryCommandHandler;
			_updateCategoryCommandHandler = updateCategoryCommandHandler;
			_removeCategoryCommandHandler = removeCategoryCommandHandler;
			_getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
			_getCategoryQueryHandler = getCategoryQueryHandler;
		}

		[HttpGet]
		public async Task<IActionResult> CategoryList()
		{
			var values = await _getCategoryQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{CategoryId}")]
		public async Task<IActionResult> GetCategory(int CategoryId)
		{
			var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(CategoryId));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
		{
			await _createCategoryCommandHandler.Handle(createCategoryCommand);
			return Ok("Kategori Bilgisi Başarıyla Eklenmiştir");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveCategory(int CategoryId)
		{
			await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(CategoryId));
			return Ok("Kategori Başarıyla Silinmiştir");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
		{
			await _updateCategoryCommandHandler.Handle(updateCategoryCommand);
			return Ok("Kategori Başarıyla Güncellenmiştir");
		}
	}
}
