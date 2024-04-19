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
	public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
	{
		private readonly IRepository<SocialMedia> _socialMediaRepository;

		public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> socialMediaRepository)
		{
			_socialMediaRepository = socialMediaRepository;
		}

		public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _socialMediaRepository.GetByIdAsync(request.Id);
			return new GetSocialMediaByIdQueryResult
			{
				SocialMediaId = value.SocialMediaId,
				Name = value.Name,
				Icon = value.Icon,
				Url = value.Url
			};
		}
	}
}
