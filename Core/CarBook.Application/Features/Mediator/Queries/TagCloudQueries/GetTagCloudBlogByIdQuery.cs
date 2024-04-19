using CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudBlogByIdQuery : IRequest<List<GetTagCloudBlogByIdQueryResult>>
    {
        public int BlogId { get; set; }

        public GetTagCloudBlogByIdQuery(int blogId)
        {
            BlogId = blogId;
        }
    }
}
