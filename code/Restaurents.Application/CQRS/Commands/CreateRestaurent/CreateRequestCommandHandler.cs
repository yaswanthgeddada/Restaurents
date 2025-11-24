using System;
using AutoMapper;
using MediatR;
using Restaurents.Application.UserHttpContext;
using Restaurents.Domain.Entities;
using Restaurents.Infrastructure.Repositories.Interfaces;

namespace Restaurents.Application.Commands.CreateRestaurent;

public class CreateRequestCommandHandler(IMapper _mapper, IRestaurentRepository _repo, IUserContext userContext) : IRequestHandler<CreateRestaurentCommand, int>
{
    public async Task<int> Handle(CreateRestaurentCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = userContext.GetCurrentUser()!.Id;
        var entity = _mapper.Map<Restaurent>(request);
        entity.OwnerId = currentUserId;
        var response = await _repo.CreateRestaurent(entity);
        return response;
    }
}
