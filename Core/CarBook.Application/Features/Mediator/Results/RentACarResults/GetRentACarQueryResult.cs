﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.RentACarResults
{
    public class GetRentACarQueryResult
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CoverImage { get; set; }
    }
}
