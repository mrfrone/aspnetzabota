﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using aspnetzabota.Admin.Services.Extentions;
using aspnetzabota.Admin.Datamodel.Mapping;
using aspnetzabota.Content.Services.Extensions;
using aspnetzabota.Common.PasswordService.Extensions;
using aspnetzabota.Admin.Datamodel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using aspnetzabota.Common.Datamodel.PasswordHashing;
using aspnetzabota.Common.AutoMapper.Extensions;
using aspnetzabota.Web.Common;
using aspnetzabota.Web.Common.Filters;

namespace aspnetzabota
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IHostingEnvironment _environment;
        public Startup(IHostingEnvironment hostEnv)
        {
             var _config = new ConfigurationBuilder().
                SetBasePath(hostEnv.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostEnv.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = _config.Build();
            _environment = hostEnv;

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JwtSettings>(Configuration.GetSection(nameof(JwtSettings)));
            services.Configure<PasswordHashingSettings>(Configuration.GetSection(nameof(PasswordHashingSettings)));

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddAdminServices(connectionString);
            services.AddContentServices(connectionString);
            services.AddPasswordHashing();
            services.AddScoped<IIdentityRequestStorage, IdentityRequestStorage>();



            services.AddMiMapping(
                //typeof(Content.Datamodel.Mapping.MappingProfile),
                typeof(Admin.Datamodel.Mapping.MappingProfile)
                );

            var jwtOptions = Configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = jwtOptions.Issuer,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = jwtOptions.Audience,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,
                            // установка ключа безопасности
                            IssuerSigningKey = jwtOptions.GetSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                        };
                    });

            services.AddMvcCore(options =>
            {
                options.Filters.Add<IdentityStorageFilterAttribute>();
            })
                .AddJsonFormatters().AddJsonOptions(options =>
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
            app.UseAuthentication();    
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/");
            });
        }
    }
}
