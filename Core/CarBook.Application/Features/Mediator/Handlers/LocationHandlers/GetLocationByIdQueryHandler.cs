using CarBook.Application.Features.Editör.Queries.LocationQueries;
using CarBook.Application.Features.Editör.Results.LocationResults;
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
	public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
	{
		private readonly IRepository<Location> _locationRepository;

		public GetLocationByIdQueryHandler(IRepository<Location> locationRepository)
		{
			_locationRepository = locationRepository;
		}

		public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _locationRepository.GetByIdAsync(request.Id);

			return new GetLocationByIdQueryResult
			{
				LocationId = value.LocationId,
				Name = value.Name
			};
		}
	}
}
