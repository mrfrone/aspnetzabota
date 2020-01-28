using aspnetzabota.Content.Services.Price;
using aspnetzabota.Content.Services.Schedule;
using Microsoft.Extensions.DependencyInjection;
using aspnetzabota.Content.Repository.Extensions;
using aspnetzabota.Content.Services.Slider;
using aspnetzabota.Content.Services.News;
using aspnetzabota.Content.Services.Review;
using aspnetzabota.Content.Services.Department;
using aspnetzabota.Content.Services.Licenses;
using aspnetzabota.Content.Services.Category;

namespace aspnetzabota.Content.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static object AddContentServices(this IServiceCollection services, string connectionString)
        {
            services.AddContentRepository(connectionString);
            services.AddScoped<IPrice, Price.Price>();
            services.AddScoped<ISchedule, Schedule.Schedule>();
            services.AddScoped<ISlider, Slider.Slider>();
            services.AddScoped<INews, News.News>();
            services.AddScoped<IReview, Review.Review>();
            services.AddScoped<IDepartment, Department.Department>();
            services.AddScoped<ILicenses, Licenses.Licenses>();
            services.AddScoped<ICategory, Category.Category>();
            return services;
        }
    }
}
