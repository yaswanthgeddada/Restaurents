using System;
using MediatR;

namespace Restaurents.Application.CQRS.Commands.UnAssignUserRole;


public class UnAssignUserRoleCommand : IRequest
{
    public string UserEmail { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}
