using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.RezervationCommands
{
    public class CreateRezervationCommand : IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string TC { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CarId { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOfLocationId { get; set; }
        public int Age { get; set; }
        public DateTime BirthdayDate { get; set; }
        public int DriverLicanseYear { get; set; }
        public string Status { get; set; }
    }
}
