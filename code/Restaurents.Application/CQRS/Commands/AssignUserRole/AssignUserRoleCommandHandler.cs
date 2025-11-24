using System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurents.Domain.Entities;
using Restaurents.Domain.Exceptions;

namespace Restaurents.Application.CQRS.Commands.AssignUserRole;

public class AssignUserRoleCommandHandler(
    ILogger<AssignUserRoleCommandHandler> logger,
    UserManager<User> userManager,
    RoleManager<IdentityRole> roles
    ) : IRequestHandler<AssignUserRoleCommand>
{
    public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("assign user role request {@request}", request);
        var user = await userManager.FindByEmailAsync(request.UserEmail) ?? throw new NotFoundException($"user not found with email - {request.UserEmail}");

        var role = await roles.FindByNameAsync(request.RoleName) ?? throw new NotFoundException($"Role not found - {request.RoleName}");

        await userManager.AddToRoleAsync(user, role.Name!);
    }
}
