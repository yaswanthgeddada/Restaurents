using System;
using MediatR;
using Restaurents.Application.DTOs;
using Restaurents.Domain.Entities;

namespace Restaurents.Application.CQRS.Queries.GetDishById;

public class GetDishByIdQuery(int RestaurentId, int DishId) : IRequest<Dish>
{
    public int RestaurentId { get; } = RestaurentId;
    public int DishId { get; } = DishId;
}
