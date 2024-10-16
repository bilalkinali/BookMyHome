using System.Diagnostics;
using BookMyHome.Application.Query;
using BookMyHome.Infrastructure.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BookMyHome.Application.Helpers;
using BookMyHome.Infrastructure.Repositories;
using BookMyHome.Application.RepositoryInterface;
using BookMyHome.Domain.DomainServices;
using BookMyHome.Infrastructure.ExternalServices;
using BookMyHome.Infrastructure.ExternalServices.ServiceProxyImpl;

namespace BookMyHome.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBookingQuery, BookingQuery>();
            services.AddScoped<IAccommodationRepository, AccommodationRepository>();
            services.AddScoped<IHostQuery, HostQuery>();
            services.AddScoped<IHostRepository, HostRepository>();
            services.AddScoped<IGuestRepository, GuestRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork<BookMyHomeContext>>();
            services.AddScoped<IValidateAddressDomainService, ValidateAddressDomainService>();

            // External services
            services.AddHttpClient<IAddressServiceProxy, AddressServiceProxy>(client =>
            {
                var uri = configuration.GetSection("ExternalServices:AddressServiceDAWA:Uri").Value;
                Debug.Assert(String.Empty != null, "String.Empty != null");
                client.BaseAddress = new Uri(uri ?? string.Empty);
            });

            // Database
            // https://github.com/dotnet/SqlClient/issues/2239
            // https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
            // Add-Migration InitialMigration -Context BookMyHomeContext -Project BookMyHome.DatabaseMigration
            // Update-Database -Context BookMyHomeContext -Project BookMyHome.DatabaseMigration
            services.AddDbContext<BookMyHomeContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString
                        ("BookMyHomeDbConnection"),
                    x =>
                        x.MigrationsAssembly("BookMyHome.DatabaseMigration")));

            return services;
        }
    }
}
