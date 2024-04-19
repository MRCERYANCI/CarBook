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
	public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
	{
		private readonly IRepository<Pricing> _pricingrepository;

		public CreatePricingCommandHandler(IRepository<Pricing> pricingrepository)
		{
			_pricingrepository = pricingrepository;
		}

		public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
		{
			await _pricingrepository.CreateAsync(new Pricing
			{
				Name = request.Name
			});
		}
	}
}
