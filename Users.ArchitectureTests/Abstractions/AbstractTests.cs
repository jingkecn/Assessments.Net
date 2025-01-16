using System.Reflection;
using Users.Application;
using Users.Domain.Models;

namespace Users.ArchitectureTests.Abstractions;

public abstract class AbstractTests
{
    protected static readonly Assembly ApplicationAssembly = typeof(DependencyInjection).Assembly;
    protected static readonly Assembly DomainAssembly = typeof(User).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(Infrastructure.DependencyInjection).Assembly;
    protected static readonly Assembly PresentationAssembly = typeof(Presentation.DependencyInjection).Assembly;
}
