using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BannerInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerFirstQueryHandler
    {
        private readonly IBannerRepository _bannerRepository;

        public GetBannerFirstQueryHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<GetBannerQueryResultFirst> Handle()
        {
            var values = _bannerRepository.GetBannerFirstAllDefault();
            return new GetBannerQueryResultFirst
            {
                BannerId = values.BannerId,
                VideoDescription = values.VideoDescription,
                Description = values.Description,
                Title = values.Title,
                VideoUrl = values.VideoUrl
            };
        }
    }
}
