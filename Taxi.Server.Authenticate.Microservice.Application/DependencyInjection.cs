﻿using Microsoft.Extensions.DependencyInjection;

namespace Taxi.Server.Authenticate.Microservice.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            return services;
        }
    };
}
