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
	public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
	{
		private readonly IRepository<Service> _servicerepository;

		public CreateServiceCommandHandler(IRepository<Service> servicerepository)
		{
			_servicerepository = servicerepository;
		}

		public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
		{
			await _servicerepository.CreateAsync(new Service
			{
				Description = request.Description,
				IconUrl = request.IconUrl,
				Title = request.Title
			});
		}
	}
}
