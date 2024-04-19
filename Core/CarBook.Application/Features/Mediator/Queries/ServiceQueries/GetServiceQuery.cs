using CarBook.Application.Features.Editör.Results.ServiceResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Editör.Queries.ServiceQueries
{
	public class GetServiceQuery : IRequest<List<GetServiceQueryResult>>
	{
	}
}
