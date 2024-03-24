using Microsoft.AspNetCore.Identity;
using Taxi.Server.Authenticate.Microservice.Domain.Entities;
using Taxi.Server.Authenticate.Microservice.Infrastructure.Data;

namespace Taxi.Server.Authenticate.Microservice.Api.Configuration
{
    internal static class IdentityConfiguration
    {
        internal static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<DBContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
