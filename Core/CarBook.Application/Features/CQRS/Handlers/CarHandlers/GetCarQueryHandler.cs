using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarQueryHandler
	{
		private readonly IRepository<Car> _carrepository;

		public GetCarQueryHandler(IRepository<Car> carrepository)
		{
			_carrepository = carrepository;
		}
		public async Task<List<GetCarQueryResult>> Handle()
		{
			var values = await _carrepository.GetAllAsync();
			return values.Select(x => new GetCarQueryResult
			{
				CarId = x.CarId,
				BrandId = x.BrandId,
				Model = x.Model,
				CoverImage = x.CoverImage,
				km = x.km,
				Transmission = x.Transmission,
				Seat = x.Seat,
				Fuel = x.Fuel,
				BigImageUrl = x.BigImageUrl,
				Vitrin = x.Vitrin,
				Luggage= x.Luggage
			}).ToList();
		}
	}
}
