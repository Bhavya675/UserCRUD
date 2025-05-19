using ControllerApi.Interfaces;
using ControllerApi.Services;
using ControllerApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPhoneService, PhoneService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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
