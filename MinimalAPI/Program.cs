using MinimalAPI.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConnectDatabase(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.RegisterRepository();
builder.Services.RegisterServices();
builder.Services.RegisterValidators();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// app.MapGet("/", () => "Hello World!");
app.RegisterEndpoints();
app.Run();
