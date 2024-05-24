using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DtoLayer.Dtos.CarDescriptionDtıos
{
    public class ResultCarDescriptionByCarIdDto
    {
        public int CarDescriptionId { get; set; }
        public string Detail { get; set; }
        public int CarId { get; set; }
    }
}
