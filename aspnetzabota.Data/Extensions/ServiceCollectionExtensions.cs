using aspnetzabota.Content.Database.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace aspnetzabota.Content.Database.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddContentDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ContentContext>(builder =>
            {
                builder.UseNpgsql(connectionString, options =>
                {
                    options.MigrationsAssembly("aspnetzabota.Web");
                    options.EnableRetryOnFailure();
                    options.MigrationsHistoryTable("__EFMigrationsHistory", ContentContext.SchemaName);
                });
            });

            return services;
        }
    }
}
