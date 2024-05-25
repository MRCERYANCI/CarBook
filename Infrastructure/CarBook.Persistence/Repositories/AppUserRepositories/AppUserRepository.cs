using CarBook.Application.Interfaces.AppUserInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly CarBookContext _carBookContext;

        public AppUserRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public async Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filterExpression)
        {
            var values = await _carBookContext.AppUsers.Where(filterExpression).FirstOrDefaultAsync();
            return values;
        }
    }
}
