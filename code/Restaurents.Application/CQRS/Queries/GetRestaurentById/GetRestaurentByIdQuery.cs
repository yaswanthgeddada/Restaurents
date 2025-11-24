using System;
using MediatR;
using Restaurents.Application.DTOs;

namespace Restaurents.Application.Queries.GetRestaurentById;

public class GetRestaurentByIdQuery : IRequest<RestaurentDto?>
{
    public int Id { get; set; }
}
