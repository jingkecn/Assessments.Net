using FluentAssertions;
using NetArchTest.Rules;
using Users.ArchitectureTests.Abstractions;

namespace Users.ArchitectureTests.Layers;

public sealed class DomainLayerTests : AbstractTests
{
    [Fact]
    public void Domain_Should_NotHaveDependencyOn_Application()
    {
        var result = Types
            .InAssembly(DomainAssembly)
            .Should().NotHaveDependencyOn(ApplicationAssembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Domain_Should_NotHaveDependencyOn_Infrastructure()
    {
        var result = Types
            .InAssembly(DomainAssembly)
            .Should().NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Domain_Should_NotHaveDependencyOn_Presentation()
    {
        var result = Types
            .InAssembly(DomainAssembly)
            .Should().NotHaveDependencyOn(PresentationAssembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
