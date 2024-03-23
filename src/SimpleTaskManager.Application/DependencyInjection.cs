using Microsoft.Extensions.DependencyInjection;
using PWSoftware.BaseApplication;

namespace SimpleTaskManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddBaseApplication(typeof(DependencyInjection).Assembly);

        return services;
    }
}
