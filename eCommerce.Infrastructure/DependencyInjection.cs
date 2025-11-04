using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static  class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration  configuration)
    {
        // Infrastructure service registrations go here
        services.AddTransient<DapperDbContext>();
        services.AddSingleton(configuration);
        services.AddSingleton<IUserRepository, UserRepository>();
        return services;
    }
}
