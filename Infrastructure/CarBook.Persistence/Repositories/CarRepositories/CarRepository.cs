using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
	public class CarRepository : ICarRepository
	{
		private readonly CarBookContext _context;

		public CarRepository(CarBookContext context)
		{
			_context = context;
		}

        public int GetCarCount()
        {
			return _context.Cars.Count();
        }

		public Car GetCarsByIdListBrands(int id)
		{
			return _context.Cars.Where(y => y.CarId == id).Include(x => x.Brand).FirstOrDefault();
		}

		public List<Car> GetCarsListBrands()
		{
			return  _context.Cars.Include(x => x.Brand).ToList();
		}

        public List<Car> GetLast5CarsWithBrands()
        {
			var values = _context.Cars.Count();
			if(values >= 5)
			{
				return _context.Cars.Include(x => x.Brand).OrderByDescending(x=>x.CarId).Take(5).ToList();
			}
			else
			{
				return  _context.Cars.Include(x => x.Brand).OrderByDescending(x=>x.CarId).Take(values).ToList();
            }
        }
    }
}
