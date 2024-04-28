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
            var values = _carBookContext.Comments.Include(x => x.Blog).GroupBy(y => y.Blog.Title).Select(z => new
            {
                BlogTitle = z.Key,
                Count = z.Count()
            }).OrderByDescending(z => z.Count).Select(z => z.BlogTitle).Take(1).FirstOrDefault();

            return values;
        }

        public string GetBrandNameByMaxCar()
        {
            var values = _carBookContext.Cars.Include(x => x.Brand).GroupBy(y => y.Brand.Name).Select(z => new
            {
                BrandName = z.Key,
                Count = z.Count()
            }).OrderByDescending(z=>z.Count).Select(z=>z.BrandName).Take(1).FirstOrDefault();

            return values;
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
            var PricingId = (int)_carBookContext.Pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingId).FirstOrDefault();
            var Amount = (decimal)_carBookContext.CarPricings.Where(y => y.PricingId == PricingId).Min(x => x.Amount);
            var CardId = (int)_carBookContext.CarPricings.Where(x => x.Amount == Amount).Select(y => y.CarId).FirstOrDefault();
            var BrandModel = (string)_carBookContext.Cars.Where(x => x.CarId == CardId).Include(y => y.Brand).Select(z => z.Brand.Name).FirstOrDefault();
            if (BrandModel != null)
            {
                return BrandModel;
            }
            return null;
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
            //SELECT  Brands.Name + ' - ' + Cars.Model FROM CarPricings INNER JOIN Cars ON CarPricings.CarId = Cars.CarId INNER JOIN Brands ON Cars.BrandId = Brands.BrandId Where PricingId = (SELECT PricingId FROM Pricings WHERE Name = 'Günlük') AND Amount = (SELECT MAX(AMOUNT) FROM CarPricings WHERE PricingId = (SELECT PricingId FROM Pricings WHERE Name = 'Günlük'))

            var PricingId = (int)_carBookContext.Pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingId).FirstOrDefault();
            var Amount = (decimal)_carBookContext.CarPricings.Where(y => y.PricingId == PricingId).Max(x => x.Amount);
            var CardId = (int)_carBookContext.CarPricings.Where(x => x.Amount == Amount).Select(y => y.CarId).FirstOrDefault();
            var BrandModel = (string)_carBookContext.Cars.Where(x => x.CarId == CardId).Include(y => y.Brand).Select(z => z.Brand.Name).FirstOrDefault();
            if (BrandModel != null)
            {
                return BrandModel;
            }
            return null;
        }
    }
}
