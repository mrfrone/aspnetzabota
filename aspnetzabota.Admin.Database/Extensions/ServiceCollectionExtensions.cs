using aspnetzabota.Admin.Database.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace aspnetzabota.Admin.Database.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAdminDatabase(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<AdminContext>(builder =>
            {
                builder.UseNpgsql(connectionString, options =>
                {
                    options.MigrationsAssembly("aspnetzabota.Web");
                    options.EnableRetryOnFailure();
                    options.MigrationsHistoryTable("__EFMigrationsHistory", AdminContext.SchemaName);
                });
            });

            return services;
        }
    }
}
