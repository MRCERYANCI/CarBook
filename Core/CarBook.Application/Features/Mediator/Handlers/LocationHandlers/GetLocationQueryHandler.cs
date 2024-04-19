﻿using CarBook.Application.Features.Editör.Queries.LocationQueries;
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
	public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
	{
		private readonly IRepository<Location> _locationRepository;

		public GetLocationQueryHandler(IRepository<Location> locationRepository)
		{
			_locationRepository = locationRepository;
		}

		public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
		{
			var values = await _locationRepository.GetAllAsync();

			return values.Select(x => new GetLocationQueryResult
			{
				LocationId = x.LocationId,
				Name = x.Name
			}).ToList();
		}
	}
}
