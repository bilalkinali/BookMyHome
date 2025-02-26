﻿using System.Diagnostics;
using AddressServiceDAWA.Application;
using AddressServiceDAWA.Application.Command;
using AddressServiceDAWA.Application.Query;
using AddressServiceDAWA.Domain.DomainServices;
using AddressServiceDAWA.Infrastructure.ExternalServices.ServiceProxyImpl;
using AddressServiceDAWA.Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AddressServiceDAWA.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IAddressQuery, AddressQuery>();

        // External services
        services.AddHttpClient<IDawaProxy, DawaProxy>(client =>
        {
            var uri = configuration.GetSection("ExternalServices:Dawa:Uri").Value;
            Debug.Assert(string.Empty != null, "String.Empty != null");
            client.BaseAddress = new Uri(uri ?? string.Empty);
        });

        services.AddHttpClient<IBookMyHomeProxy, BookMyHomeProxy>(client =>
        {
            var uri = configuration.GetSection("ExternalServices:BookMyHome:Uri").Value;
            Debug.Assert(string.Empty != null, "String.Empty != null");
            client.BaseAddress = new Uri(uri ?? string.Empty);
        });


        // Database
        // https://github.com/dotnet/SqlClient/issues/2239
        // https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
        // Add-Migration InitialMigration -Context AddressContext -Project AddressServiceDAWA.DatabaseMigration
        // Update-Database -Context AddressContext -Project AddressServiceDAWA.DatabaseMigration
        services.AddDbContext<AddressContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString
                    ("AddressDbConnection"),
                x =>
                    x.MigrationsAssembly("AddressServiceDAWA.DatabaseMigration")));

        return services;
    }
}