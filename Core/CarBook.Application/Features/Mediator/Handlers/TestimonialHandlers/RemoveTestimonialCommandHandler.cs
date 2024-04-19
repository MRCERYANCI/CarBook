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
    public class RemoveTestimonialCommandHandler:IRequestHandler<RemoveTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _testimonialrepository;

        public RemoveTestimonialCommandHandler(IRepository<Testimonial> testimonialrepository)
        {
            _testimonialrepository = testimonialrepository;
        }

        public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var value = await _testimonialrepository.GetByIdAsync(request.Id);
                if(value != null)
                {
                    await _testimonialrepository.RemoveAsync(value);
                }
            }
        }
    }
}
