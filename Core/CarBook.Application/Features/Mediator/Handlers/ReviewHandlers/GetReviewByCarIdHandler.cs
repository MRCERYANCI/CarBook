using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewByCarIdHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _reviewRepository.GetReviewByCarId(request.Id);
            return values.Select(x => new GetReviewByCarIdQueryResult
            {
                CarId = x.CarId,
                CustomerComment = x.CustomerComment,
                CustomerImage = x.CustomerImage,
                CustomerName = x.CustomerName,
                RaytingValue = x.RaytingValue,
                ReviewDate = x.ReviewDate,
                ReviewId = x.ReviewId
            }).ToList();
        }
    }
}
