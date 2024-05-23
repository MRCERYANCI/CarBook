using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _carBookContext;

        public CarFeatureRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public void ChangeCarFeatureAvailableToFalse(int CarFeatureId)
        {
            var values = _carBookContext.CarFeatures.Where(x => x.CarFeatureId == CarFeatureId).FirstOrDefault();
            values.Available = false;
             _carBookContext.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToTrue(int CarFeatureId)
        {
            var values = _carBookContext.CarFeatures.Where(x => x.CarFeatureId == CarFeatureId).FirstOrDefault();
            values.Available = true;
            _carBookContext.SaveChanges();
        }

        public void CreateCarFeatureByCar(CarFeature carFeature)
        {
            _carBookContext.CarFeatures.Add(carFeature);
            _carBookContext.SaveChanges();
        }

        public async Task<List<CarFeature>> GetCarFeaturesByCarId(int CarId)
        {
            return await _carBookContext.CarFeatures.Where(y => y.CarId == CarId).Include(x => x.Feature).ToListAsync();
        }
    }
}
