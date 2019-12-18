using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using aspnetzabota.Content.Database.Context;
using aspnetzabota.Content.Database.Repository.News;
using aspnetzabota.Content.Database.Repository.Category;
using aspnetzabota.Content.Database.Repository.Department;
using aspnetzabota.Content.Database.Repository.Licenses;
using aspnetzabota.Content.Database.Repository.Review;
using aspnetzabota.Content.Database.Repository.Slider;
using aspnetzabota.Content.Services.Price;
using aspnetzabota.Content.Services.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace aspnetzabota
{
    public class Startup
    {
        private IConfigurationRoot _config;

        public Startup(IWebHostEnvironment hostEnv)
        {
            _config = new ConfigurationBuilder().
                SetBasePath(hostEnv.ContentRootPath).
                AddJsonFile("appsettings.json").
                Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ContentContext>(options => 
                options.UseMySql(_config.GetConnectionString("DefaultConnection"), options =>
                           options.MigrationsHistoryTable("__EFMigrationsHistory")));

            services.AddScoped<ILicenses, LicensesRepository>();
            services.AddScoped<IDepartment, DepartmentRepository>();
            services.AddScoped<IPrice, Price>();
            services.AddScoped<ISchedule, Schedule>();
            services.AddScoped<IReview, ReviewRepository>();
            services.AddScoped<ISlider, SliderRepository>();
            services.AddScoped<INews, NewsRepository>();
            services.AddScoped<ICategory, CategoryRepository>();
            //services.AddMvcCore().AddJsonFormatters().AddJsonOptions(options =>
            //{
            //    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            //    options.SerializerSettings.Formatting = Formatting.None;
            //    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //    options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            //    options.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
            //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //    //options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            //}).AddRazorViewEngine();
            services.AddMvcCore().AddRazorViewEngine().AddMvcOptions(x => x.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/");
            });
        }
    }
}
