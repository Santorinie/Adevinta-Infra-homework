using System;
using Adevinta_hw.Data;
using Microsoft.EntityFrameworkCore;

namespace Adevinta_hw.Helpers
{
    public class MigrationBuilder
    {
        public MigrationBuilder()
        {

            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public MySqlServerVersion serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<KonyvtarDbContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("Default"), serverVersion)
                //logs (not for production)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }

    }
}

