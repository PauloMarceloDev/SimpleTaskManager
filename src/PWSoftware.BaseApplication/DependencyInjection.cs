using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PWSoftware.BaseApplication.Abstractions.Behaviors;

namespace PWSoftware.BaseApplication;

public static class DependencyInjection
{
    public static IServiceCollection AddBaseApplication(this IServiceCollection services, Assembly assembly)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly);

            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));

            configuration.AddOpenBehavior(typeof(QueryCachingBehavior<,>));
        });

        services.AddValidatorsFromAssembly(assembly, includeInternalTypes: true);


        return services;
    }
}
