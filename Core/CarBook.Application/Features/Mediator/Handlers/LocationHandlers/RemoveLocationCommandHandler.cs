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
	public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand>
	{
		private readonly IRepository<Location> _locationRepository;

		public RemoveLocationCommandHandler(IRepository<Location> locationRepository)
		{
			_locationRepository = locationRepository;
		}

		public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
		{
			var value = await _locationRepository.GetByIdAsync(request.Id);
			if (value != null)
			{
				await _locationRepository.RemoveAsync(value);
			}
		}
	}
}
