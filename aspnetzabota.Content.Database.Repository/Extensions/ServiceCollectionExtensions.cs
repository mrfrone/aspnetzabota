﻿using aspnetzabota.Content.Database.Repository.Category;
using aspnetzabota.Content.Database.Repository.Department;
using aspnetzabota.Content.Database.Repository.Licenses;
using aspnetzabota.Content.Database.Repository.Articles;
using aspnetzabota.Content.Database.Repository.Review;
using aspnetzabota.Content.Database.Repository.Slider;
using Microsoft.Extensions.DependencyInjection;
using aspnetzabota.Content.Database.Extensions;
using aspnetzabota.Content.Database.Repository.PriceArticles;
using aspnetzabota.Content.Database.Entities;
using aspnetzabota.Content.Database.Repository.DoctorInfo;

namespace aspnetzabota.Content.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddContentRepository(this IServiceCollection services, string connectionString)
        {
            services.AddContentDatabase(connectionString);
            services.AddScoped<IPriceArticlesRepository, PriceArticlesRepository>();
            services.AddScoped<IDoctorInfoRepository, DoctorInfoRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<IArticlesRepository, ArticlesRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ILicensesRepository, LicensesRepository>();
            return services;
        }
    }
}
