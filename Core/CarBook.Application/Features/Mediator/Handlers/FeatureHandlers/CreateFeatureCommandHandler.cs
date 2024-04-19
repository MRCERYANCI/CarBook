using CarBook.Application.Features.Editör.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Editör.Handlers.FeatureHandlers
{
	public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
	{
		private readonly IRepository<Feature> _featurerepository;

		public CreateFeatureCommandHandler(IRepository<Feature> featurerepository)
		{
			_featurerepository = featurerepository;
		}

		public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
		{
		     await _featurerepository.CreateAsync(new Feature
			{
				Name = request.Name
			});
		}
	}
}
