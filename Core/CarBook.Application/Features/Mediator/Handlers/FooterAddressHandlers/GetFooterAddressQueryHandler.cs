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
	public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
	{
		private readonly IRepository<FooterAddress> _footeraddressrepository;

		public GetFooterAddressQueryHandler(IRepository<FooterAddress> footeraddressrepository)
		{
			_footeraddressrepository = footeraddressrepository;
		}

		public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
		{
			var values = await _footeraddressrepository.GetAllAsync();

			return values.Select(x => new GetFooterAddressQueryResult
			{
				FooterAddressId = x.FooterAddressId,
				Address = x.Address,
				Description = x.Description,
				Phone = x.Phone,
				Mail = x.Mail
			}).ToList();
		}
	}
}
