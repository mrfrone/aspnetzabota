using aspnetzabota.Content.Database.Repository.Category;
using aspnetzabota.Content.Database.Repository.Department;
using aspnetzabota.Content.Database.Repository.Licenses;
using aspnetzabota.Content.Database.Repository.News;
using aspnetzabota.Content.Database.Repository.Review;
using aspnetzabota.Content.Database.Repository.Slider;
using Microsoft.Extensions.DependencyInjection;
using aspnetzabota.Content.Database.Extensions;


namespace aspnetzabota.Content.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddContentRepository(this IServiceCollection services, string connectionString)
        {
            services.AddContentDatabase(connectionString);
            services.AddScoped<ILicenses, LicensesRepository>();
            services.AddScoped<IDepartment, DepartmentRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<ICategory, CategoryRepository>();
            return services;
        }
    }
}
