using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Entities;
using MinimalAPI.Services.Interface;
using MinimalAPI.Models.DTO.Request;
using MinimalAPI.Repository;
using MinimalAPI.Services;
using MinimalAPI.Common.Validators;
using MinimalAPI.Repository.Interface;
using MinimalAPI.Endpoints;
using Microsoft.OpenApi.Models;

namespace MinimalAPI.Common
{

    public static class Configuration
    {
        public static void ConnectDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ProductDbContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }

        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<ProductDTO>, ProductValidator>();
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                // c.SwaggerDoc("v1", new() { Title = "MinimalAPI API", Version = "v1" });
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MinimalAPI API", Version = "v1" });
                // Add JWT Authentication to Swagger
            });
        }

        public static void RegisterEndpoints(this WebApplication app)
        {
            app.RegisterProductAPIs();
        }
    }
}