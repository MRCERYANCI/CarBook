using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.ViewModel
{
	public class CarPricingViewModel
	{
        public CarPricingViewModel()
        {
            Amounts = new List<decimal>();
        }

        public string Model { get; set; }
		public List<Decimal> Amounts { get; set; }
		public string CoverImage { get; set; }
        public string BrandName { get; set; }
    }
}
