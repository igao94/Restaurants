﻿using FluentAssertions;
using Restaurants.Domain.Constants;
using Xunit;

namespace Restaurants.Application.Users.Tests;

public class CurrentUserTests
{
    [Fact]
    public void IsInRole_WithMatchingRole_ShouldReturnTrue()
    {
        // arrange

        var currentUser = new CurrentUser("1",
            "test@test.com",
            [UserRoles.Admin, UserRoles.User],
            null,
            null);

        // act

        var isInRole = currentUser.IsInRole(UserRoles.Admin);

        // assert

        isInRole.Should().BeTrue();
    }

    [Fact]
    public void IsInRole_WithNoMatchingRole_ShouldReturnFalse()
    {
        // arrange

        var currentUser = new CurrentUser("1",
            "test@test.com",
            [UserRoles.Admin, UserRoles.User],
            null,
            null);

        // act

        var isInRole = currentUser.IsInRole(UserRoles.Owner);

        // assert

        isInRole.Should().BeFalse();
    }

    [Fact]
    public void IsInRole_WithNoMatchingRoleCase_ShouldReturnFalse()
    {
        // arrange

        var currentUser = new CurrentUser("1",
            "test@test.com",
            [UserRoles.Admin, UserRoles.User],
            null,
            null);

        // act

        var isInRole = currentUser.IsInRole(UserRoles.Admin.ToLower());

        // assert

        isInRole.Should().BeFalse();
    }


}