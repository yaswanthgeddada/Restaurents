using System;
using MediatR;

namespace Restaurents.Application.CQRS.Commands.CreateDish;

public class DeletDishCommand(int restId) : IRequest<bool>
{
    public int RestId { get; } = restId;
}
