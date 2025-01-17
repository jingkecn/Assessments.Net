using FluentAssertions;
using NetArchTest.Rules;
using SharedKernel.Abstractions;
using Users.ArchitectureTests.Abstractions;

namespace Users.ArchitectureTests.Domain;

public sealed class DomainEventTests : AbstractTests
{
    [Fact]
    public void DomainEvents_Should_BeSealed()
    {
        var result = Types
            .InAssembly(DomainAssembly)
            .That().Inherit(typeof(DomainEvent))
            .And().HaveNameEndingWith(nameof(DomainEvent))
            .Should().BeSealed()
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void DomainEvents_Should_HaveNameEndingWith_DomainEvent()
    {
        var result = Types
            .InAssembly(DomainAssembly)
            .That().Inherit(typeof(DomainEvent))
            .Should().HaveNameEndingWith(nameof(DomainEvent))
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
