using System;
using MediatR;
using Restaurents.Domain.Entities;

namespace Restaurents.Application.CQRS.Queries.GetAllDishes;

public class GetAllDishesQuery(int restaurentId) : IRequest<IList<Dish>>
{
    public int restaurentId { get; } = restaurentId;
}
