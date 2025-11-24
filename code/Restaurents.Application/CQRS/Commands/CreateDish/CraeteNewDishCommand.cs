using System;
using MediatR;
using Restaurents.Domain.Entities;

namespace Restaurents.Application.CQRS.Commands.CreateDish;

public class CraeteNewDishCommand : IRequest<Dish>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public bool IsVeg { get; set; } = default!;
    public bool IsAvailable { get; set; } = true;
    public int? Calories { get; set; }
    public int RestaurentId { get; set; }

}
