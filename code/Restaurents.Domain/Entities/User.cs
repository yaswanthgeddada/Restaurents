using System;
using Microsoft.AspNetCore.Identity;

namespace Restaurents.Domain.Entities;

public class User : IdentityUser
{
    public List<Restaurent> Restaurents { get; set; } = default!;
}
