using ControllerApi.Interfaces;
using ControllerApi.Services;
using ControllerApi;
using Microsoft.EntityFrameworkCore;
using ControllerApi.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Name=ConnectionStrings:DefaultConnection")));
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPhoneService, PhoneService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// {
//     // Configure the database provider and connection string.
//     // UseSqlServer method configures the DbContext to use SQL Server as the database provider.
//     // The provided connection string specifies the server, database name, and credentials.
//     // Replace "Server=YourServerName;Database=YourDatabaseName;User Id=YourUsername;Password=YourPassword;"
//     // with your actual SQL Server details.
//     optionsBuilder.UseNpgsql("Server=YourServerName;Database=YourDatabaseName;User Id=YourUsername;Password=YourPassword;");
// }

// Run Middleware Component
// app.Run(async (context) =>
// {
// await context.Response.WriteAsync("Run Middleware Component Works and Getting Response from First Middleware!");
// });

// Register custom middleware
// app.UseMiddleware<RequestLoggingMiddleware>();

// app.UseSwaggerUI(c =>
// {
//     c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
//     c.RoutePrefix = ""; // serves Swagger UI at root "/"
// });

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
