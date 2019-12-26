using aspnetzabota.Common.PasswordService.JwtGenerate;
using aspnetzabota.Common.PasswordService.PasswordHash;
using Microsoft.Extensions.DependencyInjection;

namespace aspnetzabota.Common.PasswordService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPasswordHashing(this IServiceCollection services)
        {
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IPasswordHashCalculator, PasswordHashCalculator>();
            return services;
        }
    }
}
