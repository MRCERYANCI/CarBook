using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
	public class Pricing
	{
        public int PricingId { get; set; }
        public string Name { get; set; }

		//Car Pricing Arası İlişki
		public ICollection<CarPricing> CardPricings { get; set; }
	}
}
