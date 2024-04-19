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
	public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
	{

		private readonly IRepository<Pricing> _pricingrepository;

		public RemovePricingCommandHandler(IRepository<Pricing> pricingrepository)
		{
			_pricingrepository = pricingrepository;
		}

		public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
		{
			var value = await _pricingrepository.GetByIdAsync(request.Id);
			if(value!= null)
			{
				await _pricingrepository.RemoveAsync(value);
			}
		}
	}
}
