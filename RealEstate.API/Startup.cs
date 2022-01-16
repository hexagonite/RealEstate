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
using RealEstate.API.Repositories.Abstractions;
using RealEstate.API.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API
{
    public class Startup
    {
        //TODOS
        ///// add swagger
        ///// podstawowe encje
        // podstawowy controller do encji (GET i POST)
        // testy
        ///// entityframework
        ///// baza danych
        ///// propertyservice
        // middleware przechwytuj¹cy exceptiony (custom error dto)

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson(setupAction =>
            {
                setupAction.SerializerSettings.ContractResolver =
                   new CamelCasePropertyNamesContractResolver();
            }).AddXmlDataContractSerializerFormatters();

            services.AddSwaggerGen();

            services.AddDbContextPool<RealEstateContext>(options =>
            {
                options.UseLazyLoadingProxies();
                var connectionString = Configuration.GetConnectionString("RealEstateDb");
                #if DEBUG
                    options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
                #else
                    options.UseSqlServer(connectionString);
                #endif
            });

            #region Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAddressRepository, AddressRepository>();
            //services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IPropertyTypeRepository, PropertyTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();
            #endregion
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
