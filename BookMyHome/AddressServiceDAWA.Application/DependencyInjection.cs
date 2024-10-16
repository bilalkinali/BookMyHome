using AddressServiceDAWA.Application.Command;
using Microsoft.Extensions.DependencyInjection;

namespace AddressServiceDAWA.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAddressCommand, AddressCommand>();
        return services;
    }
}