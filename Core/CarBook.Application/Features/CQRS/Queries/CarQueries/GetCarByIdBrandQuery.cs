using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CarQueries
{
	public class GetCarByIdBrandQuery
	{
        public int Id { get; set; }

		public GetCarByIdBrandQuery(int ıd)
		{
			Id = ıd;
		}
	}
}
