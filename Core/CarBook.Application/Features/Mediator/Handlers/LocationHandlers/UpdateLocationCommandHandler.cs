using CarBook.Application.Features.Editör.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Editör.Handlers.LocationHandlers
{
	public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
	{
		private readonly IRepository<Location> _locationRepository;

		public UpdateLocationCommandHandler(IRepository<Location> locationRepository)
		{
			_locationRepository = locationRepository;
		}

		public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
		{
			var value = await _locationRepository.GetByIdAsync(request.LocationId);
			if(value != null)
			{
				value.Name = request.Name;
				await _locationRepository.UpdateAsync(value);
			}
		}
	}
}
