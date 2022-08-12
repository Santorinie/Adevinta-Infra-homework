using System;
using Adevinta_hw.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MigartionBuilder
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
                Console.WriteLine(Configuration.GetConnectionString("Local"));
                options.UseMySql(Configuration.GetConnectionString("Local"), serverVersion);
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}

