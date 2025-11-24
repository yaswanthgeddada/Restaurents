using System;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurents.Application.DTOs;
using Restaurents.Domain.Entities;
using Restaurents.Domain.RepositoryInterfaces;

namespace Restaurents.Application.CQRS.Queries.GetDishById;

public class GetDishByIdQueryHandler(IDishRepository dishRepository, ILogger<GetDishByIdQueryHandler> logger) : IRequestHandler<GetDishByIdQuery, Dish>
{
    public async Task<Dish> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
    {
        var res = await dishRepository.GetDishById(request.RestaurentId, request.DishId);

        logger.LogInformation("GetDishByIdQueryHandler {@res}", res);

        return res;
    }
}
