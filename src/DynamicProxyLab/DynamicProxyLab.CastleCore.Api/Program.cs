using DynamicProxyLab.CastleCore.Api.Services;
using DynamicProxyLab.CastleCore.Api.Extensions;
using DynamicProxyLab.CastleCore.Api.Interceptors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddInterceptedSingleton<IWeatherService, WeatherService, DurationInterceptor>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
