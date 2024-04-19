using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarWithBrandQueryHandler
	{
		private readonly ICarRepository _carrepository;

		public GetCarWithBrandQueryHandler(ICarRepository carrepository)
		{
			_carrepository = carrepository;
		}

		public List<GetCarWithBrandQueryResult> Handle()
		{
			var values = _carrepository.GetCarsListBrands();
			return values.Select(x => new GetCarWithBrandQueryResult
			{
				CarId = x.CarId,
				BrandName = x.Brand.Name,
				Model = x.Model,
				CoverImage = x.CoverImage,
				km = x.km,
				Transmission = x.Transmission,
				Seat = x.Seat,
				Fuel = x.Fuel,
				BigImageUrl = x.BigImageUrl,
				Vitrin = x.Vitrin
			}).ToList();
		}
	}
}
