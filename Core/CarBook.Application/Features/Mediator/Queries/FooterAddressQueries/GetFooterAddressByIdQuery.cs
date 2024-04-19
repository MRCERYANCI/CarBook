using CarBook.Application.Features.Editör.Results.FooterAddressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Editör.Queries.FooterAddressQueries
{
	public class GetFooterAddressByIdQuery : IRequest<GetFooterAddressByIdQueryResult>
	{
        public int Id { get; set; }

		public GetFooterAddressByIdQuery(int id)
		{
			Id = id;
		}
	}
}
