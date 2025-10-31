using eCommerce.Core.ServiceContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration  configuration)
    {
        // Infrastructure service registrations go here
        services.AddTransient<IUserService, IUserService>();
        return services;
    }
}
