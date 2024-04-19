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
	public class RemoveCarCommandHandler
	{
		private readonly IRepository<Car> _carrepository;

		public RemoveCarCommandHandler(IRepository<Car> carrepository)
		{
			_carrepository = carrepository;
		}

		public async Task Handle(RemoveCarCommand removeCarCommand)
		{
			var value = await _carrepository.GetByIdAsync(removeCarCommand.Id);
			await _carrepository.RemoveAsync(value);
		}
	}
}
