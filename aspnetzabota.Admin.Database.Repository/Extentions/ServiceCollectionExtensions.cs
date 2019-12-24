using aspnetzabota.Admin.Database.Extensions;
using aspnetzabota.Admin.Database.Repository.Identities;
using aspnetzabota.Admin.Database.Repository.Tokens;
using Microsoft.Extensions.DependencyInjection;

namespace aspnetzabota.Admin.Database.Repository.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAdminRepository(this IServiceCollection services, string connectionString)
        {
            services.AddAdminDatabase(connectionString);
            services.AddScoped<ITokensRepository, TokensRepository>();
            services.AddScoped<IIdentitiesRepository, IdentitiesRepository>();
            return services;
        }
    }
}
