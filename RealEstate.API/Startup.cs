using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using RealEstate.API.Contexts;
using RealEstate.API.Middlewares;
using RealEstate.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace RealEstate.API
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(setupAction =>
                {
                    setupAction.ReturnHttpNotAcceptable = true;
                })
                .AddNewtonsoftJson(setupAction =>
                {
                    setupAction.SerializerSettings.ContractResolver =
                        new CamelCasePropertyNamesContractResolver();
                }).AddXmlDataContractSerializerFormatters()
                .AddFluentValidation(c =>
                    {
                        c.RegisterValidatorsFromAssemblyContaining<Startup>();
                        c.DisableDataAnnotationsValidation = false;
                    }); ;

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen();

            services.AddDbContextPool<IRealEstateContext, RealEstateContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("RealEstateDb");
                
                if (_webHostEnvironment.IsDevelopment())
                {
                    options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
                }
                else
                {
                    options.UseSqlServer(connectionString);
                }

            });

            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IPropertyTypeService, PropertyTypeService>();
            services.AddSingleton<IMemoryCache, MemoryCache>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseMiddleware<ErrorHandlingMiddleware>();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
