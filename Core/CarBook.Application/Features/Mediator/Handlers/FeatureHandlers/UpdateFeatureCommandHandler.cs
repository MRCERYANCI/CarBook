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
	public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
	{
		private readonly IRepository<Feature> _featurerepository;

		public UpdateFeatureCommandHandler(IRepository<Feature> featurerepository)
		{
			_featurerepository = featurerepository;
		}

		public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
		{
			var value = await _featurerepository.GetByIdAsync(request.FeatureId);
			if (value != null)
			{
				value.Name = request.Name;

				await _featurerepository.UpdateAsync(value);
			}
		}
	}
}
