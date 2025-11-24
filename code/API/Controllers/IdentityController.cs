using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurents.Application.CQRS.Commands.AssignUserRole;
using Restaurents.Application.CQRS.Commands.UnAssignUserRole;
using Restaurents.Domain.Constents;

namespace Restaurents.API.Controllers;

[ApiController]
[Route("/api/identity")]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [HttpPost("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> AssignRole(AssignUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("unassignRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> UnassignRole(UnAssignUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

}
