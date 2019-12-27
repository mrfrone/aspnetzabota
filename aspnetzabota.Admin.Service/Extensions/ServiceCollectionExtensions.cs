using aspnetzabota.Admin.Database.Repository.Extentions;
using aspnetzabota.Admin.Services.Identities;
using aspnetzabota.Admin.Services.Login;
using Microsoft.Extensions.DependencyInjection;

namespace aspnetzabota.Admin.Services.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAdminServices(this IServiceCollection services, string connectionString)
        {
            services.AddAdminRepository(connectionString);
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ILoginService, LoginService>();
            return services;
        }
    }
}
