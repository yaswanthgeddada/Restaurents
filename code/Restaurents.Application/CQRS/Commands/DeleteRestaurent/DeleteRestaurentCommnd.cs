using System;
using MediatR;

namespace Restaurents.Application.Commands.DeleteRestaurent;

public class DeleteRestaurentCommnd(int id) : IRequest<bool>
{
    public int Id { get; } = id;
}
