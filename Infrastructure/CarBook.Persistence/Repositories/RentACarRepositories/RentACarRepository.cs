using CarBook.Application.Interfaces.RentACarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly CarBookContext _carBookContext;

        public RentACarRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filterExpression)
        {
            return await _carBookContext.rentACars.Include(x=>x.Car).ThenInclude(y=>y.Brand).Where(filterExpression).ToListAsync();
        }
    }
}
