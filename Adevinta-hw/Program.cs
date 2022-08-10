using System.Configuration;
using Adevinta_hw.Controllers;
using Adevinta_hw.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// API healthcheck
builder.Services.AddHealthChecks();

// MySQL server version
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

// Add DB context and connect remote MySQL DB to the ORM
builder.Services.AddDbContext<KonyvtarDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("Default"),serverVersion)
                //logs (not for production)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());

var app = builder.Build();

// Configure the HTTP request pipeline.

// Map healthcheck to /health route
app.MapHealthChecks("/health");

app.UseAuthorization();

app.MapControllers();

app.Run();

