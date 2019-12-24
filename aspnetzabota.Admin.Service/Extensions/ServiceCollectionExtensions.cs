using Microsoft.Extensions.DependencyInjection;

namespace aspnetzabota.Admin.Database.Repository.Extentions
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
