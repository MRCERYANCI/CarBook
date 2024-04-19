using CarBook.Application.Features.Editör.Queries.ServiceQueries;
using CarBook.Application.Features.Editör.Results.ServiceResults;
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
	public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
	{
		private readonly IRepository<Service> _servicerepository;

		public GetServiceByIdQueryHandler(IRepository<Service> servicerepository)
		{
			_servicerepository = servicerepository;
		}

		public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _servicerepository.GetByIdAsync(request.Id);

			return new GetServiceByIdQueryResult
			{
				ServiceId = request.Id,
				IconUrl = value.IconUrl,
				Description = value.Description,
				Title = value.Title
			};
		}
	}
}
