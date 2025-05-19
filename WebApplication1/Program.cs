using WebApplication1;
using WebApplication1.Interfaces;
using WebApplication1.Services;

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
    //     app.UseSwaggerUI(c =>
    // {
    //     c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    //     c.RoutePrefix = ""; // serves Swagger UI at root "/"
    // });

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

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();



app.Run();
