using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBook.Application.Features.Mediator.Results.SocialMediaResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
	public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
	{
		private readonly IRepository<SocialMedia> _socialMediaRepository;

		public GetSocialMediaQueryHandler(IRepository<SocialMedia> socialMediaRepository)
		{
			_socialMediaRepository = socialMediaRepository;
		}

		public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
		{
			var values = await _socialMediaRepository.GetAllAsync();

			return values.Select(x => new GetSocialMediaQueryResult
			{
				SocialMediaId = x.SocialMediaId,
				Name = x.Name,
				Icon = x.Icon,
				Url = x.Url
			}).ToList();
		}
	}
}
