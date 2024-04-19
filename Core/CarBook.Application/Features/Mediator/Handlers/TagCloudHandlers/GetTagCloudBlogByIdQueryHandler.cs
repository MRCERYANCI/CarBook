using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudBlogByIdQueryHandler : IRequestHandler<GetTagCloudBlogByIdQuery, List<GetTagCloudBlogByIdQueryResult>>
    {
        private readonly ITagCloudRepository _tagCloudRepository;

        public GetTagCloudBlogByIdQueryHandler(ITagCloudRepository tagCloudRepository)
        {
            _tagCloudRepository = tagCloudRepository;
        }

        public async Task<List<GetTagCloudBlogByIdQueryResult>> Handle(GetTagCloudBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var values = _tagCloudRepository.GetBlogByIdList(request.BlogId);

            return values.Select(x => new GetTagCloudBlogByIdQueryResult
            {
                TagCloudId = x.TagCloudId,
                BlogId = x.BlogId,
                Title = x.Title
            }).ToList();
        }
    }
}
