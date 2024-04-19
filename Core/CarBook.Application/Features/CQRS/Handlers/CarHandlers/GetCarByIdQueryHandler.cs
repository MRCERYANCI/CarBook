using CarBook.Application.Features.CQRS.Queries.CarQueries;
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
	public class GetCarByIdQueryHandler
	{
		private readonly IRepository<Car> _carrepository;

		public GetCarByIdQueryHandler(IRepository<Car> carrepository)
		{
			_carrepository = carrepository;
		}
		public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery getCarByIdQuery)
		{
			var values = await _carrepository.GetByIdAsync(getCarByIdQuery.Id);

			return new GetCarByIdQueryResult
			{
				CarId = values.CarId,
				BrandId = values.BrandId,
				Model = values.Model,
				CoverImage = values.CoverImage,
				km = values.km,
				Transmission = values.Transmission,
				Seat = values.Seat,
				Fuel = values.Fuel,
				BigImageUrl = values.BigImageUrl,
				Vitrin = values.Vitrin,
				Luggage= values.Luggage
			};		
		}
	}
}
