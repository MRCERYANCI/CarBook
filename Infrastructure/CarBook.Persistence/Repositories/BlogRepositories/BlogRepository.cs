using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
	public class BlogRepository : IBlogRepository
	{
		private readonly CarBookContext _context;

		public BlogRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<Blog> GetLast3BlogsWithAuthors()
		{
			var values = _context.Blogs.Count();
			if (values >= 3)
			{
				 return _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogId).Take(3).ToList();
			}
			else
			{
				return _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogId).Take(values).ToList();
			}
		}

        public List<Blog> GetLastBlogsWithAuthors()
        {
            return _context.Blogs.Include(x => x.Author).Include(y=>y.Category).OrderByDescending(x => x.BlogId).ToList();
        }
    }
}
