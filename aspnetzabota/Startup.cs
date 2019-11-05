using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Repository;
using aspnetzabota.Data;
using aspnetzabota.Data.Services;

namespace aspnetzabota
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>();
            services.AddTransient<IPriceService, PriceService>();
            services.AddTransient<IDoctorSchedule, DoctorSchedule>();
            services.AddTransient<IReview, ReviewRepository>();
            services.AddTransient<ISlider, SliderRepository>();
            services.AddTransient<INews, NewsRepository>();
            services.AddTransient<INewsCategory, CategoryRepository>();
            services.AddMvcCore().AddRazorViewEngine();
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
                template: "{controller=HomeController}/{action=Index}/");
            });
        }
    }
}
