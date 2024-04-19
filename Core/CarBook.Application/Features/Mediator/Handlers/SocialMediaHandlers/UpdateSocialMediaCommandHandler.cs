using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
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
	public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
	{
		private readonly IRepository<SocialMedia> _socialMediaRepository;

		public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> socialMediaRepository)
		{
			_socialMediaRepository = socialMediaRepository;
		}

		public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
		{
			var value = await _socialMediaRepository.GetByIdAsync(request.SocialMediaId);
			if (value != null)
			{
				value.Url = request.Url;
				value.Name = request.Name;
				value.Icon=request.Icon;
				await _socialMediaRepository.UpdateAsync(value);
			}
		}
	}
}
