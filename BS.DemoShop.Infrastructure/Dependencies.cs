using BS.DemoShop.Infrastructure.Data;
using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System;
using BS.DemoShop.Core.Interfaces;
using BS.DemoShop.Infrastructure.Data.Queries;
using BS.DemoShop.Infrastructure.Services;

namespace BS.DemoShop.Infrastructure
{
    public class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<BSDemoShopContext>(options => options.UseSqlServer(configuration.GetConnectionString("BSDemoShopConnection")));

            #region CloudinarySettings
            var cloudName = configuration.GetSection("CloudinarySettings:CloudName").Value;
            var apiKey = configuration.GetSection("CloudinarySettings:ApiKey").Value;
            var apiSecret = configuration.GetSection("CloudinarySettings:ApiSecret").Value;

            if (new[] { cloudName, apiKey, apiSecret }.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException("Please specify Cloudinary account details!");
            }
            services.AddSingleton(new Cloudinary(new Account(cloudName, apiKey, apiSecret)));
            #endregion
        }


    }
}