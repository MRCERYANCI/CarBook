using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DtoLayer.Dtos.ReviewDtos
{
    public class CreateReviewDto
    {
        public string CustomerName { get; set; }
        public string CustomerImage { get; set; }
        public string CustomerComment { get; set; }
        public int RaytingValue { get; set; }
        public int CarId { get; set; }
    }
}
