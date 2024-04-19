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
    public class RemoveTagCloudComandHandler : IRequestHandler<RemoveTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _tagcloudrepository;

        public RemoveTagCloudComandHandler(IRepository<TagCloud> tagcloudrepository)
        {
            _tagcloudrepository = tagcloudrepository;
        }

        public async Task Handle(RemoveTagCloudCommand request, CancellationToken cancellationToken)
        {
            var value = await _tagcloudrepository.GetByIdAsync(request.Id);

            if (value != null)
            {
                await _tagcloudrepository.RemoveAsync(value);
            }
        }
    }
}
