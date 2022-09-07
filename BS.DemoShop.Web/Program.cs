using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BS.DemoShop.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace BS.DemoShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExist(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        private static void CreateDbIfNotExist(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                var env = host.Services.GetRequiredService<IHostEnvironment>();
                if (env.IsDevelopment())
                {
                    try
                    {
                        var context = services.GetRequiredService<BSDemoShopContext>();
                        BSDemoShopContextSeed.SeedDevelopment(context, logger);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the DB.");
                    }
                }
                else
                {
                    try
                    {
                        var context = services.GetRequiredService<BSDemoShopContext>();
                        BSDemoShopContextSeed.SeedForProduction(context, logger);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the DB.");
                    }
                }
                
            }
        }
    }
}