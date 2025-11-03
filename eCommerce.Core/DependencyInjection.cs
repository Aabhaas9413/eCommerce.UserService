using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration  configuration)
    {
        // Infrastructure service registrations go here
        services.AddTransient<IUserService, UserService>();
        //Internally detects all validators and adds them as services,
        //all classes with abstract validator class will be added as services.
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        return services;
    }
}
