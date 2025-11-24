using System;
using MediatR;
using Restaurents.Application.DTOs;
using Restaurents.Domain.Entities;

namespace Restaurents.Application.Commands.UpdateRestaurent;

public class UpdateRestaurentCommand() : IRequest<RestaurentDto?>
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
}
