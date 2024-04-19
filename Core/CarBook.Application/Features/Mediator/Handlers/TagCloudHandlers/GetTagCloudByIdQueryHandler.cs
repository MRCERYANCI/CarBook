using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQuerResult>
    {
        private readonly IRepository<TagCloud> _tagcloudrepository;

        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> tagcloudrepository)
        {
            _tagcloudrepository = tagcloudrepository;
        }

        public async Task<GetTagCloudByIdQuerResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _tagcloudrepository.GetByIdAsync(request.Id);

            return new GetTagCloudByIdQuerResult
            {
                TagCloudId = value.TagCloudId,
                BlogId = value.BlogId,
                Title = value.Title
            };
        }
    }
}
