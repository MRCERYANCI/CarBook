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
	public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
	{
		private readonly IRepository<Location> _locationRepository;

		public CreateLocationCommandHandler(IRepository<Location> locationRepository)
		{
			_locationRepository = locationRepository;
		}

		public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
		{
			await _locationRepository.CreateAsync(new Location
			{
				Name = request.Name
			});
		}
	}
}
