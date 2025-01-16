using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Users.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) => services
        .AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped)
        .AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
}
