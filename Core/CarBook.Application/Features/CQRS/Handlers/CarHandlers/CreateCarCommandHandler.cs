using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class CreateCarCommandHandler
	{
		private readonly IRepository<Car> _carrepository;

		public CreateCarCommandHandler(IRepository<Car> carrepository)
		{
			_carrepository = carrepository;
		}

		public async Task Handle(CreateCarCommand createCarCommand)
		{
			await _carrepository.CreateAsync(new Car
			{
				BrandId = createCarCommand.BrandId,
				Model = createCarCommand.Model,
				CoverImage = createCarCommand.CoverImage,
				km = createCarCommand.km,
				Transmission = createCarCommand.Transmission,
				Seat = createCarCommand.Seat,
				Fuel = createCarCommand.Fuel,
				BigImageUrl = createCarCommand.BigImageUrl,
				Vitrin = createCarCommand.Vitrin,
				Luggage= createCarCommand.Luggage
			});
		}
	}
}
