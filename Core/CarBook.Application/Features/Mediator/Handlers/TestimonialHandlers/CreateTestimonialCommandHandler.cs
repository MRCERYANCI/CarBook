using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _testimonialrepository;

        public CreateTestimonialCommandHandler(IRepository<Testimonial> testimonialrepository)
        {
            _testimonialrepository = testimonialrepository;
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            if(request != null)
            {
                await _testimonialrepository.CreateAsync(new Testimonial
                {
                    Comment = request.Comment,
                    Title = request.Title,
                    ImageUrl = request.ImageUrl,
                    Name = request.Name
                });
            }
        }
    }
}
