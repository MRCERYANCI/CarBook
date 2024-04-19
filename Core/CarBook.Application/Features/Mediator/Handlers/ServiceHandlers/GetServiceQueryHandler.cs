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
	public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
	{
		private readonly IRepository<Service> _servicerepository;

		public GetServiceQueryHandler(IRepository<Service> servicerepository)
		{
			_servicerepository = servicerepository;
		}

		public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
		{
			var values = await _servicerepository.GetAllAsync();

			return values.Select(x => new GetServiceQueryResult
			{
				ServiceId = x.ServiceId,
				Description = x.Description,
				IconUrl = x.IconUrl,
				Title = x.Title
			}).ToList();
		}
	}
}
