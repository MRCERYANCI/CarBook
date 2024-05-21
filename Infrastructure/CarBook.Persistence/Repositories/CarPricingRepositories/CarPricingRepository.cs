using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModel;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

		public List<CarPricingViewModel> GetCarPricingWithTimePeriod()  ///İstek Dizinin Dışındaydı Hatası Veriyor
		{
           List<CarPricingViewModel> carPricingViewModels = new List<CarPricingViewModel>();
            using(var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From (Select Model,Name,CoverImage,PricingId,Amount From CarPricings inner join Cars on CarPricings.CarId=Cars.CarId inner join Brands on Brands.BrandId=Cars.BrandId) As SourceTable Pivot(Sum(Amount) For PricingId In([8],[9],[11])) as PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel pricingViewModel = new CarPricingViewModel()
                        {
                            BrandName = reader["Name"].ToString(),
                            Model = reader["Model"].ToString(),
                            CoverImage = reader["CoverImage"].ToString(),
                            Amounts = new List<decimal>
                            {
                                Convert.ToDecimal(reader["8"]),
                                Convert.ToDecimal(reader["9"]),
                                Convert.ToDecimal(reader["11"])
                            }
                        };
                        carPricingViewModels.Add(pricingViewModel);
                    }
                }
                _context.Database.CloseConnection();
                return carPricingViewModels;
			}
		}

		public List<CarPricing> GetCarsWithPricings()
        {
            return _context.CarPricings.Include(x => x.Pricing).Include(y => y.Car).ThenInclude(z => z.Brand).Where(h => h.PricingId == 7).ToList();
        }
    }
}
