using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DtoLayer.Dtos.RentACarDtos
{
    public class ResultRentACarDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CoverImage { get; set; }
    }
}
