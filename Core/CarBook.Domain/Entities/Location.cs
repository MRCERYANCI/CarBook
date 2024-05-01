using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
	public class Location
	{
        public int LocationId { get; set; }
        public string Name { get; set; }


        //Location RentACar Arası İlişki
        public ICollection<RentACar> RentACars { get; set; }

        //Location RentACarProcess Arası İlişki
        public ICollection<RentACarProcess> RentACarProcessPickUpLocation { get; set; }
        public ICollection<RentACarProcess> RentACarProcessDropOffLocation { get; set; }

        //Reseervation RentACarProcess Arası İlişki
        public ICollection<Reservation> ReservationProcessPickUpLocation { get; set; }
        public ICollection<Reservation> ReservationProcessDropOffLocation { get; set; }
    }
}
