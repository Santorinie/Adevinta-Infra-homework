var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// API healthcheck
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Map healthcheck to /health route
app.MapHealthChecks("/health");

app.UseAuthorization();

app.MapControllers();

app.Run();

