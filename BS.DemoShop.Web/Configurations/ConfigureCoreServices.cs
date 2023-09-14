
using BS.DemoShop.Core.Interfaces;
using BS.DemoShop.Infrastructure.Data;
using BS.DemoShop.Infrastructure.Data.Queries;
using BS.DemoShop.Infrastructure.Services;
using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System;

namespace BS.DemoShop.Web.Configurations
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductQueryService, ProductQueryService>();
            services.AddScoped<IAppPasswordHasher, SHA256Hasher>();

            //services.AddScoped<IEmailSender, SendGridEmailSender>();
            services.AddScoped<IEmailSender, MailKitEmailSender>();
            services.AddScoped<IPhotoUploader, CloudinaryPhotoUploader>();

            return services;
            
        }
    }
}
