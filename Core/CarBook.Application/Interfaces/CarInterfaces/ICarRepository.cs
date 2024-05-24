using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarInterfaces
{
	public interface ICarRepository
	{
		List<Car> GetCarsListBrands();
		List<Car> GetLast5CarsWithBrands();
		Car GetCarsByIdListBrands(int id);
		int GetCarCount();
	}
}
