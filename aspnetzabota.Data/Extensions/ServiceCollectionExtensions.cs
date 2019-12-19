using aspnetzabota.Content.Database.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace aspnetzabota.Content.Database.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddContentDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ContentContext>(options =>
                options.UseMySql(connectionString, opt =>
                           opt.MigrationsHistoryTable("__EFMigrationsHistory")));

            return services;
        }
    }
}
