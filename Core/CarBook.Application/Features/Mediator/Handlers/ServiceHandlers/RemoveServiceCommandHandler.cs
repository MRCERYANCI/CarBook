using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
	public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
	{
		private readonly IRepository<Service> _servicerepository;

		public RemoveServiceCommandHandler(IRepository<Service> servicerepository)
		{
			_servicerepository = servicerepository;
		}

		public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
		{
			var value = await _servicerepository.GetByIdAsync(request.Id);
			if (value != null)
			{
				await _servicerepository.RemoveAsync(value);
			}
		}
	}
}
