using CarBook.Application.Features.Editör.Results.FeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Editör.Queries.FeatureQueries
{
	public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>>  //GetFeatureQuery çağrıldığında bana GetFeatureQueryResult listeleyecek
	{

	}
}
