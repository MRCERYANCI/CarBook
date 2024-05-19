using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [StringLength(11)]
        public string TC { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int PickUpLocationId { get; set; }
        public Location PickUpLocation { get; set; }
        public int DropOfLocationId { get; set; }
        public Location DropOffLocation { get; set; }
        public int Age { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthdayDate { get; set; }
        public int DriverLicanseYear { get; set; }
        public string Status { get; set; }
    }
}
