var builder = WebApplication.CreateBuilder(args);

// Add service to the container

var app = builder.Build();

// Configure for the HTTP request pipeline. 

app.Run();
