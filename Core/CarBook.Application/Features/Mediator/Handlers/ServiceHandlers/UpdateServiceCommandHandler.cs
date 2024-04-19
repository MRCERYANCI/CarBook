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
	public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
	{
		private readonly IRepository<Service> _servicerepository;

		public UpdateServiceCommandHandler(IRepository<Service> servicerepository)
		{
			_servicerepository = servicerepository;
		}

		public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
		{
			var value = await _servicerepository.GetByIdAsync(request.ServiceId);
			if (value != null)
			{
				value.Description = request.Description;
				value.Title = request.Title;
				value.IconUrl = request.IconUrl;
				await _servicerepository.UpdateAsync(value);
			}
		}
	}
}
