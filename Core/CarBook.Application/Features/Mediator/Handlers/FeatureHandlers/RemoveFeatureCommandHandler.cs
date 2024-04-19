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
	public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
	{
		private readonly IRepository<Feature> _featurerepository;

		public RemoveFeatureCommandHandler(IRepository<Feature> featurerepository)
		{
			_featurerepository = featurerepository;
		}

		public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
		{
			var value = await _featurerepository.GetByIdAsync(request.Id);
			if(value != null)
			{
				await _featurerepository.RemoveAsync(value);
			}
		}
	}
}
