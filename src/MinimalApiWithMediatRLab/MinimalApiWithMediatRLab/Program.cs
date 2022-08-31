using MediatR;
using MinimalApiWithMediatRLab.Requests;
using MinimalApiWithMediatRLab.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(x => x.AsScoped(), typeof(Program));
builder.Services.AddSingleton<ICustomerService, CustomerService>();

var app = builder.Build();

app.MediateGet<GetCustomerRequest>("customer/{id}");

app.Run();