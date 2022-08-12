using Adevinta_hw.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MigartionBuilder;



Console.WriteLine("Applying migrations");
var webHost = new WebHostBuilder()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .UseStartup<MigrationBuilder>()
    .Build();
using (var context = (KonyvtarDbContext)webHost.Services.GetService(typeof(KonyvtarDbContext)))
{
    context.Database.Migrate();
}
Console.WriteLine("Done");

