using CarBook.Application.Features.Editör.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Editör.Handlers.PricingHandlers
{
	public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
	{
		private readonly IRepository<Pricing> _pricingrepository;

		public UpdatePricingCommandHandler(IRepository<Pricing> pricingrepository)
		{
			_pricingrepository = pricingrepository;
		}

		public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
		{
			var value = await _pricingrepository.GetByIdAsync(request.PricingId);
			if (value != null)
			{
				value.Name = request.Name;
				await _pricingrepository.UpdateAsync(value);
			};
		}
	}
}
