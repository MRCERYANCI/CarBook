using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DtoLayer.Dtos.FeatureDtos
{
    public class ResultFeatureAvaliable
    {
        public int FeatureId { get; set; }
        public int CarId { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; } = false;
    }
}
