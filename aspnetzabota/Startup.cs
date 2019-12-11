using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Repository;
using aspnetzabota.Data;
using aspnetzabota.Data.Services;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace aspnetzabota
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>();
            services.AddScoped<ILicenses, LicensesRepository>();
            services.AddScoped<IDepartment, DepartmentRepository>();
            services.AddScoped<IPriceService, PriceService>();
            services.AddScoped<IDoctorSchedule, DoctorSchedule>();
            services.AddScoped<IReview, ReviewRepository>();
            services.AddScoped<ISlider, SliderRepository>();
            services.AddScoped<INews, NewsRepository>();
            services.AddScoped<INewsCategory, CategoryRepository>();
            services.AddMvcCore().AddJsonFormatters().AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.Formatting = Formatting.None;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                options.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            }).AddRazorViewEngine();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
