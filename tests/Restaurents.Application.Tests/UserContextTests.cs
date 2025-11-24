using System;
using System.Security.Claims;
using FluentAssertions;
using FluentAssertions.Equivalency;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Http;
using Moq;
using Restaurents.Application.UserHttpContext;
using Restaurents.Domain.Constents;

namespace Restaurents.Application.Tests;

public class UserContextTests
{

    [Fact]
    public void GetCurrentUser_WithUserContextNotPresent_ShouldThrowInvalidExpression()
    {

        //arrage
        var httpContextAccessorMoq = new Mock<IHttpContextAccessor>();
        httpContextAccessorMoq.Setup(x => x.HttpContext).Returns((HttpContext)null!);

        var UserContext = new UserContext(httpContextAccessorMoq.Object);

        //act
        Action action = () => UserContext.GetCurrentUser();

        //assert
        action.Should().Throw<InvalidOperationException>().WithMessage("CurrentUser is null");

    }

    [Fact]
    public void GetCurrentUser_WithAuthenticaedUser_ShouldReturnCurrentUser()
    {
        //arrange
        var httpContextAccessor = new Mock<IHttpContextAccessor>();

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, "1"),
            new(ClaimTypes.Email, "testuser@gmail.com"),
            new(ClaimTypes.Role, UserRoles.User),
            new(ClaimTypes.Role, UserRoles.Admin),
        };

        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

        httpContextAccessor.Setup(h => h.HttpContext).Returns(new DefaultHttpContext()
        {
            User = user
        });

        var userContext = new UserContext(httpContextAccessor.Object);

        //act

        var currentUser = userContext.GetCurrentUser();

        //assert
        currentUser.Should().NotBeNull();
        currentUser.Id.Should().Be("1");
        currentUser.Email.Should().Be("testuser@gmail.com");
        currentUser.Roles.Should().ContainInOrder(UserRoles.User, UserRoles.Admin);

    }
}
