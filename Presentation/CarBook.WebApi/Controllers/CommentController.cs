using ApiDto.Dtos.CommentDtos;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _genericRepository;

        public CommentController(IGenericRepository<Comment> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _genericRepository.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(CreateCommentDto createCommentDto)
        {
            var value = new Comment
            {
                Name = createCommentDto.Name,
                Description = createCommentDto.Description,
                CreatedDate = createCommentDto.CreatedDate,
                Status = createCommentDto.Status,
                Email = createCommentDto.Email,
                PhoneNumber = createCommentDto.PhoneNumber,
                BlogId = createCommentDto.BlogId
            };
            _genericRepository.Create(value);
            return Ok("Yorum Başarıyla Eklenmiştir");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int CommentId)
        {
            var value = _genericRepository.FindById(CommentId);
            if (value != null)
            {
                _genericRepository.Remove(value);
            }
            return Ok("Yorum Başarıyla Silinmiştir");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _genericRepository.Update(comment);
            return Ok("Yorum Başarıyla Güncellenmiştir");
        }

        [HttpGet("{CommentId}")]
        public IActionResult GetByIdComment(int CommentId)
        {
            var value = _genericRepository.FindById(CommentId);
            if (value != null)
            {
                return Ok(value);
            }
            return Ok();
        }

        [HttpGet("BlogListByBlogId")]
        public IActionResult BlogListByBlogId(int BlogId)
        {
            var value = _genericRepository.GetById(BlogId);
            if (value != null)
            {
                return Ok(value);
            }
            return Ok();
        }

        [HttpGet("GetCountCommentBlog")]
        public IActionResult GetCountCommentBlog(int BlogId)
        {
            return Ok(_genericRepository.GetCountCommentBlog(BlogId));
        }
    }
}
