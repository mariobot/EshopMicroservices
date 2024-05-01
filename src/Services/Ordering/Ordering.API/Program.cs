using Ordering.API;
using Ordering.Application;
using Ordering.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services
    .AddApplicationServices()
    .AddInfraestructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

app.UseApiServices();

// Configure the HTTP request pipeline

app.Run();
