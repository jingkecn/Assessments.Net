using FluentAssertions;
using Users.Domain.Models;

namespace Users.UnitTests.Domain;

public sealed class AddressTests
{
    [Theory]
    [InlineData("", "Nantes", "44000", "Place Commerce", nameof(country))]
    [InlineData("France", "", "44000", "Place Commerce", nameof(city))]
    [InlineData("France", "Nantes", "", "Place Commerce", nameof(postCode))]
    [InlineData("France", "Nantes", "44000", "", nameof(street))]
    public void Constructor_Should_ThrowArgumentException_When_AnyParameterIsEmpty(
        string country,
        string city,
        string postCode,
        string street,
        string paramName)
    {
        // Act
        var act = () => new Address(country, city, postCode, street);

        // Assert
        act
            .Should().ThrowExactly<ArgumentException>()
            .Which.ParamName.Should().Be(paramName);
    }
}
