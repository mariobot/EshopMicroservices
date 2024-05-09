var builder = WebApplication.CreateBuilder(args);

// Add service to the container

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

// Configure for the HTTP request pipeline.
app.MapReverseProxy();

app.Run();
