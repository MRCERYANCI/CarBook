using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.RepositoryPattern
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> GetById(int id);
        T FindById(int id);
        void Create(T entity);
        void Update(T entity);
        void Remove(T entity);

        int GetCountCommentBlog(int BlogId);
    }
}
