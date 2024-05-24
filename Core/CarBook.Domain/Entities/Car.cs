using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
	public class Car
	{
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string CoverImage { get; set; }
        public int km { get; set; } = 0;
        public string Transmission { get; set; }  //Vites Türü
        public byte Seat { get; set; }  //Koltuk Sayısı
        public byte Luggage { get; set; }  //Bagaj Sayısı
        public string Fuel { get; set; }  //Yakıt Türü
        public string BigImageUrl { get; set; }  //Büyük Görsel Yolu
        public bool Vitrin { get; set; } = false; 



        //Car CarFeature Arası İlişki
        public ICollection<CarFeature> CarFeatures { get; set; }

		//Car CarDescription Arası İlişki
		public ICollection<CarDescription> CarDescriptions { get; set; }

        //Car CardPricing Arası İlişki
        public ICollection<CarPricing> CardPricings { get; set; }

        //Car RentACar Arası İlişki
        public ICollection<RentACar> RentACars { get; set; }

        //Car RentACarProcess Arası İlişki
        public ICollection<RentACarProcess> RentACarProcesses { get; set; }

        //Car Reservastion Arası İlişki
        public ICollection<Reservation> Reservations { get; set; }

        //Car Review Arası İlişki
        public ICollection<Review> Reviews { get; set; }
    }
}
