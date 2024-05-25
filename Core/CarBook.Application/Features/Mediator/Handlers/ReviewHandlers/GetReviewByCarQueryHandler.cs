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
    public class GetReviewByCarQueryHandler : IRequestHandler<GetReviewByCarQuery, List<GetReviewByCarQueryResult>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewByCarQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<GetReviewByCarQueryResult>> Handle(GetReviewByCarQuery request, CancellationToken cancellationToken)
        {
            var values = _reviewRepository.GetReviewByCar(request.Id);
            return values.Select(x => new GetReviewByCarQueryResult
            {
                TotalScore = x.TotalScore,
                CommentCount = x.CommentCount,
                CommentScore = x.CommentScore,
                PointPercentage = x.PointPercentage
            }).ToList();
        }
    }
}
