using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarDescriptionResults
{
    public class GetCarDescriptionQueryResult
    {
        public int CarDescriptionId { get; set; }
        public string Detail { get; set; }
        public int CarId { get; set; }
    }
}
