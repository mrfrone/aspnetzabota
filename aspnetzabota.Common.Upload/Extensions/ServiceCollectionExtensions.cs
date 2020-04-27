using aspnetzabota.Common.Upload.UploadPath;
using Microsoft.Extensions.DependencyInjection;

namespace aspnetzabota.Common.Upload.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUpload(this IServiceCollection services)
        {
            services.AddScoped<IUpload, Upload>();
            services.AddScoped<IUploadPath, UploadPath.UploadPath>();

            return services;
        }
    }
}
