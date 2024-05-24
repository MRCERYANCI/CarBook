using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarByIdBarndQueryHandler
	{
		private readonly ICarRepository _carRepository;

		public GetCarByIdBarndQueryHandler(ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}

		public async Task<GetCarIdBrandQueryResult> Handle(GetCarByIdBrandQuery getCarByIdBrandQuery)
		{
			var values =  _carRepository.GetCarsByIdListBrands(getCarByIdBrandQuery.Id);

			return new GetCarIdBrandQueryResult
			{
				CarId = values.CarId,
				Model = values.Model,
				CoverImage = values.CoverImage,
				km = values.km,
				Transmission = values.Transmission,
				Seat = values.Seat,
				Fuel = values.Fuel,
				BigImageUrl = values.BigImageUrl,
				Luggage = values.Luggage,
				BrandName = values.Brand.Name
			};
		}
	}
}

