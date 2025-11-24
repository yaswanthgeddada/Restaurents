using MediatR;

namespace Restaurents.Application.Commands;

public class CreateRestaurentCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; } = default!;

    public string? ContactEmail { get; set; }
    public string? ContactNumber { get; set; } = default!;

    public DateTime CreatedAt { get; set; }


    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
}
