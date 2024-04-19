using CarBook.Application.Interfaces.BannerInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BannerRepositories
{
    public class BannerRepository : IBannerRepository
    {
        private readonly CarBookContext _carBookContext;

        public BannerRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public Banner GetBannerFirstAllDefault()
        {
            var Values = _carBookContext.Banners.OrderByDescending(x => x.BannerId).Select(x=>x.BannerId).FirstOrDefault();
            return _carBookContext.Banners.Find(Values);
        }
    }
}
