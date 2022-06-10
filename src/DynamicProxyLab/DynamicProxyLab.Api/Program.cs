using DynamicProxyLab.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IWeatherService, WeatherService>();
builder.Services.Decorate<IWeatherService, MeasuredWeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
