using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandQueryHandler
    {
        private readonly ICarRepository _carrepository;

        public GetLast5CarsWithBrandQueryHandler(ICarRepository carrepository)
        {
            _carrepository = carrepository;
        }

        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values = _carrepository.GetLast5CarsWithBrands();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                CarId = x.CarId,
                BrandName = x.Brand.Name,
                Model = x.Model,
                CoverImage = x.CoverImage,
                km = x.km,
                Transmission = x.Transmission,
                Seat = x.Seat,
                Fuel = x.Fuel,
                BigImageUrl = x.BigImageUrl,
                Vitrin = x.Vitrin
            }).ToList();
        }
    }
}
