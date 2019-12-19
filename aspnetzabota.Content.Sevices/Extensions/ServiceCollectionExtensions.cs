using aspnetzabota.Content.Database.Repository.Category;
using aspnetzabota.Content.Database.Repository.Department;
using aspnetzabota.Content.Database.Repository.Licenses;
using aspnetzabota.Content.Database.Repository.News;
using aspnetzabota.Content.Database.Repository.Review;
using aspnetzabota.Content.Database.Repository.Slider;
using aspnetzabota.Content.Services.Price;
using aspnetzabota.Content.Services.Schedule;
using Microsoft.Extensions.DependencyInjection;
using aspnetzabota.Content.Database.Extensions;


namespace aspnetzabota.Content.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddContentRepository(this IServiceCollection services, string connectionString)
        {
            services.AddContentDatabase(connectionString);
            services.AddScoped<ILicenses, LicensesRepository>();
            services.AddScoped<IDepartment, DepartmentRepository>();
            services.AddScoped<IPrice, Price.Price>();
            services.AddScoped<ISchedule, Schedule.Schedule>();
            services.AddScoped<IReview, ReviewRepository>();
            services.AddScoped<ISlider, SliderRepository>();
            services.AddScoped<INews, NewsRepository>();
            services.AddScoped<ICategory, CategoryRepository>();
            return services;
        }
    }
}
