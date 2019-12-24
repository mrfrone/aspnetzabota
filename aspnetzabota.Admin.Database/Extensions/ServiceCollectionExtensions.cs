using aspnetzabota.Admin.Database.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace aspnetzabota.Admin.Database.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAdminDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AdminContext>(options =>
                options.UseMySql(connectionString, opt =>
                           opt.MigrationsHistoryTable("__EFMigrationsHistory")));

            return services;
        }
    }
}
