using System;

namespace Restaurents.Domain.Entities;

public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public bool IsVeg { get; set; } = default!;
    public bool IsAvailable { get; set; } = true;
    public int? Calories { get; set; }


    public int RestaurentId { get; set; }

}
