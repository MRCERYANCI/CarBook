using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
	public class Brand
	{
        public int BrandId { get; set; }
        public string Name { get; set; }


        //Brand Car Tablosu Arasında İlişki
        public ICollection<Car> Cars { get; set; }
    }
}
