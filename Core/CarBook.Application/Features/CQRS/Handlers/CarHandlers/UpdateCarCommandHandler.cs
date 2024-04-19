using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class UpdateCarCommandHandler
	{
		private readonly IRepository<Car> _carrepository;

		public UpdateCarCommandHandler(IRepository<Car> carrepository)
		{
			_carrepository = carrepository;
		}

		public async Task Handle(UpdateCarCommand updateCarCommand)
		{
			var value = await _carrepository.GetByIdAsync(updateCarCommand.CarId);

			value.BrandId = updateCarCommand.BrandId;
			value.Model = updateCarCommand.Model;
			value.CoverImage = updateCarCommand.CoverImage;
			value.km = updateCarCommand.km;
			value.Transmission = updateCarCommand.Transmission;
			value.Seat = updateCarCommand.Seat;
			value.Fuel = updateCarCommand.Fuel;
			value.BigImageUrl = updateCarCommand.BigImageUrl;
			value.Vitrin = updateCarCommand.Vitrin;
			value.Luggage = updateCarCommand.Luggage;

			await _carrepository.UpdateAsync(value);
		}
	}
}
