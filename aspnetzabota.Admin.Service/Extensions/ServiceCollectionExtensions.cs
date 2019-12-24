using aspnetzabota.Admin.Database.Repository.Extentions;
using Microsoft.Extensions.DependencyInjection;

namespace aspnetzabota.Admin.Services.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAdminServices(this IServiceCollection services, string connectionString)
        {
            services.AddAdminRepository(connectionString);
            return services;
        }
    }
}
