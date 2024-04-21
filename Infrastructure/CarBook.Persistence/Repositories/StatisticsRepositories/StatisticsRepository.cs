using CarBook.Application.Interfaces.StatiscticsInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _carBookContext;

        public StatisticsRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            throw new NotImplementedException();
        }

        public string GetBrandNameByMaxCar()
        {
            throw new NotImplementedException();
        }

        public int GetAuthorCount()
        {
            return _carBookContext.Authors.Count();
        }

        public decimal GetAvgRentPriceForDaily()
        {
            //Select CONVERT(VARCHAR(15),Cast(AVG(Amount) as MONEY)) From CarPricings Where PricingId = (Select PricingId From Pricings Where Name = 'Günlük')
            return _carBookContext.CarPricings.Where(x=>x.PricingId == _carBookContext.Pricings.Where(y=>y.Name == "Günlük").Select(z=>z.PricingId).FirstOrDefault()).Average(x => x.Amount);
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            return _carBookContext.CarPricings.Where(x => x.PricingId == _carBookContext.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingId).FirstOrDefault()).Average(x => x.Amount);
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            return _carBookContext.CarPricings.Where(x => x.PricingId == _carBookContext.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingId).FirstOrDefault()).Average(x => x.Amount);
        }

        public int GetBlogCount()
        {
            return _carBookContext.Blogs.Count();
        }

        public int GetBrandCount()
        {
            return _carBookContext.Brands.Count();
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            throw new NotImplementedException();
        }

        public int GetCarCount()
        {
            return _carBookContext.Cars.Count();
        }

        public int GetCarCountByFuelElectric()
        {
            return _carBookContext.Cars.Where(x => x.Fuel == "Elektrik").Count();
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            return _carBookContext.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            return _carBookContext.Cars.Where(x => x.km <= 1000).Count();
        }

        public int GetCarCountByTranmissionIsAuto()
        {
            return _carBookContext.Cars.Where(x => x.Transmission == "Otomatik").Count();
        }

        public int getLocationCount()
        {
            return _carBookContext.Locations.Count();
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            throw new NotImplementedException();
        }
    }
}
