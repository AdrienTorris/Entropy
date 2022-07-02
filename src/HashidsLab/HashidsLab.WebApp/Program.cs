using HashidsLab.WebApp.Services;
using HashidsNet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IHashids>(_ => new Hashids(salt: "thisismyexamplesalt", minHashLength: 5));
builder.Services.AddSingleton<OrderService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
