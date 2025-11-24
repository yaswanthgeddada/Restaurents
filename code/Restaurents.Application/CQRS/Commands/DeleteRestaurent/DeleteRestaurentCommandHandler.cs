using System;
using AutoMapper;
using MediatR;
using Restaurents.Infrastructure.Repositories.Interfaces;

namespace Restaurents.Application.Commands.DeleteRestaurent;

public class DeleteRestaurentCommandHandler(IRestaurentRepository repo) : IRequestHandler<DeleteRestaurentCommnd, bool>
{
    public async Task<bool> Handle(DeleteRestaurentCommnd request, CancellationToken cancellationToken)
    {
        var restaurent = await repo.GetRestaurentById(request.Id);

        if (restaurent == null)
        {
            return false;
        }

        var isDeleted = await repo.DeleteRestaurent(restaurent);

        return isDeleted;
    }
}
