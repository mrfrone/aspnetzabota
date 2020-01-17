﻿using aspnetzabota.Content.Services.Price;
using aspnetzabota.Content.Services.Schedule;
using Microsoft.Extensions.DependencyInjection;
using aspnetzabota.Content.Repository.Extensions;
using aspnetzabota.Content.Services.Sliders;

namespace aspnetzabota.Content.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static object AddContentServices(this IServiceCollection services, string connectionString)
        {
            services.AddContentRepository(connectionString);
            services.AddScoped<IPrice, Price.Price>();
            services.AddScoped<ISchedule, Schedule.Schedule>();
            services.AddScoped<ISlider, Slider>();
            return services;
        }
    }
}
