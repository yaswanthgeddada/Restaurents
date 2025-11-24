
using FluentAssertions;
using Restaurents.Application.UserHttpContext;
using Restaurents.Domain.Constents;

namespace Restaurents.Application.Tests;

public class CurrentUserTests
{

    // TestMethod_Scenario_ExpectedResult

    [Theory]
    [InlineData(UserRoles.Admin)]
    [InlineData(UserRoles.User)]
    public void IsInRole_WithMatchingRole_ShouldReturnTrue(string userRole)
    {
        //arrange
        var currentUser = new CurrentUser("1", "testuser@gmail.com", [UserRoles.Admin, UserRoles.User]);

        //act
        var IsInRole = currentUser.IsInRole(userRole);

        //assert
        IsInRole.Should().BeTrue();
    }

    [Fact]
    public void IsInRole_WithNoMatchingRole_ShouldReturnFalse()
    {
        //arrange
        var currentUser = new CurrentUser("1", "testuser@gmail.com", [UserRoles.Admin, UserRoles.User]);

        //act
        var IsInRole = currentUser.IsInRole(UserRoles.Owner);

        //assert
        IsInRole.Should().BeFalse();
    }

    [Fact]
    public void IsInRole_WithNoMatchingRoleCase_ShouldReturnFalse()
    {
        //arrange
        var currentUser = new CurrentUser("1", "testuser@gmail.com", [UserRoles.Admin, UserRoles.User]);

        //act
        var IsInRole = currentUser.IsInRole(UserRoles.Admin.ToLower());

        //assert
        IsInRole.Should().BeFalse();
    }


}