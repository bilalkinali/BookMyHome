﻿using BookMyHome.Application.Command;
using BookMyHome.Application.Command.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookMyHome.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IBookingCommand, BookingCommand>();
            return services;
        }
    }
}
