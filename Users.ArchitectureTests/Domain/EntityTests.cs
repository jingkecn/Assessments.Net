using System.Reflection;
using FluentAssertions;
using NetArchTest.Rules;
using SharedKernel.Abstractions;
using Users.ArchitectureTests.Abstractions;

namespace Users.ArchitectureTests.Domain;

public sealed class EntityTests : AbstractTests
{
    [Fact]
    public void Entities_Should_NotHavePublicInstanceConstructors()
    {
        var entityTypes = Types
            .InAssembly(DomainAssembly)
            .That().Inherit(typeof(Entity<>))
            .GetTypes();

        var failingTypes = from entityType in entityTypes
            let constructors = entityType.GetConstructors(BindingFlags.Instance | BindingFlags.Public)
            where constructors.Length is not 0
            select entityType;

        failingTypes.Should().BeEmpty();
    }
}
