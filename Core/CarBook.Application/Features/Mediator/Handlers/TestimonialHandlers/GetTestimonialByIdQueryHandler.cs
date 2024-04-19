using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Results.TestimonailResults;
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
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _testimonialrepository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> testimonialrepository)
        {
            _testimonialrepository = testimonialrepository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _testimonialrepository.GetByIdAsync(request.Id);

            return new GetTestimonialByIdQueryResult
            {
                Comment = value.Comment,
                TestimonialId = value.TestimonialId,
                Name = value.Name,
                ImageUrl = value.ImageUrl,
                Title = value.Title
            };
        }
    }
}
