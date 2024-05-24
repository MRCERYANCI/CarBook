using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly CarBookContext _carBookContext;

        public CarDescriptionRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public async Task<CarDescription> GetCarDescriptionAsync(int CarId)
        {
            return await _carBookContext.CarDescriptions.Where(x => x.CarId == CarId).FirstOrDefaultAsync();
        }
    }
}
