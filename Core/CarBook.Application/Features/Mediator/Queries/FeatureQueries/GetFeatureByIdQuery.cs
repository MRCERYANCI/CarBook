using CarBook.Application.Features.Editör.Results.FeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Editör.Queries.FeatureQueries
{
	public class GetFeatureByIdQuery : IRequest<GetFeatureByIdQueryResult>
	{
        public int Id { get; set; }

		public GetFeatureByIdQuery(int id)
		{
			Id = id;
		}
	}
}
