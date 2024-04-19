using CarBook.Application.Features.Editör.Queries.FooterAddressQueries;
using CarBook.Application.Features.Editör.Results.FooterAddressResults;
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
	public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
	{

		private readonly IRepository<FooterAddress> _footeraddressrepository;

		public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> footeraddressrepository)
		{
			_footeraddressrepository = footeraddressrepository;
		}

		public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _footeraddressrepository.GetByIdAsync(request.Id);

			return new GetFooterAddressByIdQueryResult
			{
				FooterAddressId = value.FooterAddressId,
				Address = value.Address,
				Description = value.Description,
				Mail = value.Mail,
				Phone = value.Phone
			};
		}
	}
}
