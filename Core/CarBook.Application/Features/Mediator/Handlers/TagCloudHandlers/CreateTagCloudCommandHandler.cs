using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
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
    public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _tagcloudrepository;

        public CreateTagCloudCommandHandler(IRepository<TagCloud> tagcloudrepository)
        {
            _tagcloudrepository = tagcloudrepository;
        }

        public async Task Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
            await _tagcloudrepository.CreateAsync(new TagCloud
            {
                BlogId = request.BlogId,
                Title = request.Title
            });
        }
    }
}
