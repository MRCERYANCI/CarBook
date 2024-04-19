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
	public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommand>
	{
		private readonly IRepository<FooterAddress> _footeraddressrepository;

		public RemoveFooterAddressCommandHandler(IRepository<FooterAddress> footeraddressrepository)
		{
			_footeraddressrepository = footeraddressrepository;
		}

		public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
		{
			var value = await _footeraddressrepository.GetByIdAsync(request.Id);

			if(value != null)
			{
				await _footeraddressrepository.RemoveAsync(value);
			}
		}
	}
}
