using System.Data.Common;
using Restaurents.Domain.Entities;

namespace Restaurents.Application.UserHttpContext;

public record CurrentUser(string Id, string Email, IEnumerable<string> Roles)
{
    public bool IsInRole(string role) => Roles.Contains(role);
}
