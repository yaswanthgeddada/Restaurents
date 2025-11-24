using System;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using Restaurents.Domain.Entities;
using Restaurents.Domain.Exceptions;
using Restaurents.Domain.RepositoryInterfaces;
using Restaurents.Infrastructure.Repositories.Interfaces;

namespace Restaurents.Application.CQRS.Queries.GetAllDishes;

public class GetAllDishesQueryHandler(IDishRepository dishRepository, IRestaurentRepository restaurentRepository, ILogger<GetAllDishesQueryHandler> logger) : IRequestHandler<GetAllDishesQuery, IList<Dish>>
{
    public async Task<IList<Dish>> Handle(GetAllDishesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Inside GetAllDishesQueryHandler for restaurentId {request.restaurentId}");
        var restaurent = await restaurentRepository.GetRestaurentById(request.restaurentId);
        if (restaurent == null)
        {
            throw new NotFoundException($"restaurentId {request.restaurentId} not found");
        }

        var dishes = await dishRepository.GetAllDishes(request.restaurentId);
        logger.LogInformation("Inside GetAllDishesQueryHandler for restaurentId {@dishes}", dishes);

        return dishes.ToList();
    }
}
