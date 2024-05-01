using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using CarBook.Application.Features.Mediator.Results.RentACarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.RentACarInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _rentACarRepository;
        private readonly IRepository<Car> _repository;

        public GetRentACarQueryHandler(IRentACarRepository rentACarRepository, IRepository<Car> repository)
        {
            _rentACarRepository = rentACarRepository;
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _rentACarRepository.GetByFilterAsync(x => x.Available == request.Available && x.LocationId == request.LocationId);
            return values.Select(x => new GetRentACarQueryResult
            {
                CarId = x.CarId,
                BrandName = x.Car.Brand.Name,
                Model = x.Car.Model,
                CoverImage = x.Car.CoverImage
            }).ToList();
        }
    }
}
