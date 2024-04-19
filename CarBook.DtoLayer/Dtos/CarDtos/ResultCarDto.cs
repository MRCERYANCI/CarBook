using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DtoLayer.Dtos.CarDtos
{
    public class ResultCarDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CoverImage { get; set; }
        public int km { get; set; } = 0;
        public string Transmission { get; set; }  //Vites Türü
        public byte Seat { get; set; }  //Koltuk Sayısı
        public byte Luggage { get; set; }  //Bagaj Sayısı
        public string Fuel { get; set; }  //Yakıt Türü
        public string BigImageUrl { get; set; }  //Büyük Görsel Yolu
        public bool Vitrin { get; set; } = false;  //Yakıt Türü
    }
}
