using CarBook.Application.Features.Editör.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Editör.Handlers.FooterAddressHandlers
{
	public class CreateFooterAddresCommandHandler : IRequestHandler<CreateFooterAddressCommand>
	{
		private readonly IRepository<FooterAddress> _footeraddressrepository;

		public CreateFooterAddresCommandHandler(IRepository<FooterAddress> footeraddressrepository)
		{
			_footeraddressrepository = footeraddressrepository;
		}

		public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
		{
			await _footeraddressrepository.CreateAsync(new FooterAddress
			{
				Address = request.Address,
				Description = request.Description,
				Mail = request.Mail,
				Phone = request.Phone
			});
		}
	}
}
