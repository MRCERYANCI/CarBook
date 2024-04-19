using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarWithPricingQueryHandler : IRequestHandler<GetCarWithPricingQuery, List<GetCarWithPricingQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarWithPricingQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarWithPricingQueryResult>> Handle(GetCarWithPricingQuery request, CancellationToken cancellationToken)
        {
            var values = _carPricingRepository.GetCarsWithPricings();

            return values.Select(x => new GetCarWithPricingQueryResult
            {
                CarId = x.CarId,
                BrandName = x.Car.Brand.Name,
                Model = x.Car.Model,
                CoverImage = x.Car.CoverImage,
                km = x.Car.km,
                Transmission = x.Car.Transmission,
                Seat = x.Car.Seat,
                Luggage = x.Car.Luggage,
                Fuel = x.Car.Fuel,
                BigImageUrl = x.Car.BigImageUrl,
                PricingAmount = x.Amount,
                PricingName = x.Pricing.Name
            }).ToList();
        }
    }
}
