using FluentAssertions;
using NetArchTest.Rules;
using Users.ArchitectureTests.Abstractions;

namespace Users.ArchitectureTests.Layers;

public sealed class ApplicationLayerTests : AbstractTests
{
    [Fact]
    public void Application_Should_NotHaveDependencyOn_Infrastructure()
    {
        var result = Types
            .InAssembly(ApplicationAssembly)
            .Should().NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_NotHaveDependencyOn_Presentation()
    {
        var result = Types
            .InAssembly(ApplicationAssembly)
            .Should().NotHaveDependencyOn(PresentationAssembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
