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
	public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
	{
		private readonly IRepository<FooterAddress> _footeraddressrepository;

		public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> footeraddressrepository)
		{
			_footeraddressrepository = footeraddressrepository;
		}

		public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
		{
			var value = await _footeraddressrepository.GetByIdAsync(request.FooterAddressId);

			if (value != null)
			{
				value.Description = request.Description;
				value.Address=request.Address;
				value.Phone = request.Phone;
				value.Mail = request.Mail;

				await _footeraddressrepository.UpdateAsync(value);
			};
		}
	}
}
