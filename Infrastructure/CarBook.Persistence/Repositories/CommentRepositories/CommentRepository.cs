using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarBookContext _carBookContext;

        public CommentRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public void Create(Comment entity)
        {
            _carBookContext.Comments.Add(entity);
            _carBookContext.SaveChanges();
        }

        public Comment FindById(int id)
        {
            return _carBookContext.Comments.Find(id);
        }

        public List<Comment> GetAll()
        {
            return _carBookContext.Comments.Select(x => new Comment
            {
                CommentId = x.CommentId,
                BlogId = x.BlogId,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                Status = x.Status,
                Description = x.Description
            }).ToList();
        }

        public List<Comment> GetById(int id)
        {
            return _carBookContext.Comments.Where(x => x.BlogId == id && x.Status == true).OrderByDescending(x=>x.CreatedDate).ToList();
        }

        public void Remove(Comment entity)
        {
            _carBookContext.Comments.Remove(entity);
        }

        public void Update(Comment entity)
        {
            _carBookContext.Comments.Update(entity);
        }

        public int GetCountCommentBlog(int BlogId)
        {
            return _carBookContext.Comments.Count(x => x.BlogId == BlogId && x.Status == true);
        }
    }
}
