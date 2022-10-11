using BS.DemoShop.Core.Interfaces;
using BS.DemoShop.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace BS.DemoShop.Admin.Configurations
{
    public static class ConfigureCoreService
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            return services;
        }
    }
}       