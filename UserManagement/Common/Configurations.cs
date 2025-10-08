using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UserManagement.Common.Validators;
using UserManagement.Entities;
using UserManagement.Interfaces;
using UserManagement.Models;
using UserManagement.Repository;
using UserManagement.Services;

namespace UserManagement.Common
{

    public static class Configurations
    {
        public static void ConnectDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<UserDbContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UserDTO>, UserValidator>();
            services.AddTransient<IValidator<LoginRequestDTO>, LoginValidator>();
        }

        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");

            //JWT Authentication Configuration
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
                };
            });
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "UserManagement API", Version = "v1" });

                // Add JWT Authentication to Swagger
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token.\nExample: Bearer eyJhbGciOiJIUzI1NiIs..."
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
                });
            });
        }
    }
}