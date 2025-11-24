using System;

namespace Restaurents.Application.DTOs;

public class RestaurentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }

    public List<DishDto>? dishes { get; set; }
}
