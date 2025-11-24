using System;
using System.Net.Http.Headers;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using Restaurents.Application.CQRS.Commands.CreateDish;
using Restaurents.Domain.Exceptions;
using Restaurents.Domain.RepositoryInterfaces;
using Restaurents.Infrastructure.Repositories.Interfaces;

namespace Restaurents.Application.CQRS.Commands.DeleteDish;

public class DeleteDishCommandHandler(IDishRepository dishRepository, IRestaurentRepository restaurentRepository, ILogger<DeleteDishCommandHandler> logger) : IRequestHandler<DeletDishCommand, bool>
{
    public async Task<bool> Handle(DeletDishCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Restaurent = await restaurentRepository.GetRestaurentById(request.RestId);
            if (Restaurent == null)
            {
                throw new NotFoundException("Restaurent Not fain not found");
            }

            bool isDeleted = await dishRepository.DeleteDish(request.RestId);
            return isDeleted;
        }
        catch (System.Exception ex)
        {

            throw new NotFoundException(ex.Message);
        }
        throw new NotImplementedException();
    }
}
