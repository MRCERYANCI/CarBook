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
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _testimonialrepository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> testimonialrepository)
        {
            _testimonialrepository = testimonialrepository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            if(request != null)
            {
                var value = await _testimonialrepository.GetByIdAsync(request.TestimonialId);
                if(value != null)
                {
                    value.Title = request.Title;
                    value.Comment = request.Comment;
                    value.Name = request.Name;
                    value.ImageUrl  = request.ImageUrl;
                    await _testimonialrepository.UpdateAsync(value);
                }
            }
        }
    }
}
