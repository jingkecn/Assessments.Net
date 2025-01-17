using FluentAssertions;
using Users.Domain.Events;
using Users.Domain.Models;

namespace Users.UnitTests.Domain;

public sealed class UserTests
{
    [Fact]
    public void Create_Should_AddDomainEvent_When_AllParametersAreValid()
    {
        // Arrange
        var address = new Address("France", "Nantes", "44000", "Place Commerce");

        // Act
        var user = User.Create("John", "DOE", "john.doe@test.com", address);

        // Assert
        user.DomainEvents.OfType<UserCreatedDomainEvent>()
            .Should().ContainSingle()
            .Which.Id.Should().Be(user.Id);
    }

    [Fact]
    public void Create_Should_ReturnUser_When_AllParametersAreValid()
    {
        // Arrange
        var address = new Address("France", "Nantes", "44000", "Place Commerce");

        // Act
        var user = User.Create("John", "DOE", "john.doe@test.com", address);

        // Assert
        user.Should().NotBeNull();
    }

    [Theory]
    [InlineData("", "Doe", "john.doe@test.com", nameof(firstName))]
    [InlineData("John", "", "john.doe@test.com", nameof(lastName))]
    [InlineData("John", "Doe", "", nameof(email))]
    public void Create_Should_ThrowArgumentException_When_AnyParameterIsInvalid(
        string firstName,
        string lastName,
        string email,
        string paramName)
    {
        // Arrange
        var address = new Address("France", "Nantes", "44000", "Place Commerce");

        // Act
        var act = () => User.Create(firstName, lastName, email, address);

        // Assert
        act.Should().Throw<ArgumentException>().Which.ParamName.Should().Be(paramName);
    }

    [Fact]
    public void Update_Should_AddDomainEvent_When_AllParametersAreValid()
    {
        // Arrange
        var address = new Address("France", "Nantes", "44000", "Place Commerce");
        var user = User.Create("John", "DOE", "john.doe@test.com", address);
        const string newEmail = "john.doe@updated.com";
        var newAddress = new Address("France", "Nantes", "44300", "Petit Port");

        // Act
        _ = user.Update(newEmail, newAddress);

        // Assert
        user.DomainEvents.OfType<UserUpdatedDomainEvent>()
            .Should().ContainSingle()
            .Which.Id.Should().Be(user.Id);
    }

    [Fact]
    public void Update_Should_ReturnTrue_When_AllParametersAreValid()
    {
        // Arrange
        var address = new Address("France", "Nantes", "44000", "Place Commerce");
        var user = User.Create("John", "DOE", "john.doe@test.com", address);
        const string email = "john.doe@updated.com";
        address = user.Address with { PostCode = "44300", Street = "Petit Port" };

        // Act
        var result = user.Update(email, address);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Update_Should_ThrowArgumentException_When_AnyParameterIsInvalid()
    {
        // Arrange
        var address = new Address("France", "Nantes", "44000", "Place Commerce");
        var user = User.Create("John", "DOE", "john.doe@test.com", address);
        var email = string.Empty;
        address = user.Address with { PostCode = "44300", Street = "Petit Port" };

        // Act
        var act = () => user.Update(email, address);

        // Assert
        act.Should().ThrowExactly<ArgumentException>().Which.ParamName.Should().Be(nameof(email));
    }
}
