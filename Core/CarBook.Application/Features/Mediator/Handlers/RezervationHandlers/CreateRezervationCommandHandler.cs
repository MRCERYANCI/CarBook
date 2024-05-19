using CarBook.Application.Features.Mediator.Commands.RezervationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.RezervationHandlers
{
    public class CreateRezervationCommandHandler : IRequestHandler<CreateRezervationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateRezervationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateRezervationCommand request, CancellationToken cancellationToken)
        {
            if(request != null)
            {
                await _repository.CreateAsync(new Reservation
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    TC = request.TC,
                    BirthdayDate = request.BirthdayDate,
                    Email = request.Email,
                    DriverLicanseYear = request.DriverLicanseYear,
                    PickUpLocationId = request.PickUpLocationId,
                    DropOfLocationId = request.DropOfLocationId,
                    Description = request.Description,
                    CarId = request.CarId,
                    PhoneNumber = request.PhoneNumber,
                    Age = request.Age,
                    CreatedDate = request.CreatedDate,
                    Status = request.Status
                });
            }
        }
    }
}
