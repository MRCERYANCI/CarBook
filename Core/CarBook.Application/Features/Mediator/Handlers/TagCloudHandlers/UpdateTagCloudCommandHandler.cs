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
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _tagcloudrepository;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> tagcloudrepository)
        {
            _tagcloudrepository = tagcloudrepository;
        }

        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var value = await _tagcloudrepository.GetByIdAsync(request.TagCloudId);
            if (value != null)
            {
                value.Title= request.Title;
                value.BlogId= request.BlogId;

                await _tagcloudrepository.UpdateAsync(value);
            }
        }
    }
}
