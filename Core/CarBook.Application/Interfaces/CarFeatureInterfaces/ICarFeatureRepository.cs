using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        Task<List<CarFeature>> GetCarFeaturesByCarId(int CarId);
        void ChangeCarFeatureAvailableToFalse(int CarFeatureId);
        void ChangeCarFeatureAvailableToTrue(int CarFeatureId);
        void CreateCarFeatureByCar(CarFeature carFeature);
    }
}
