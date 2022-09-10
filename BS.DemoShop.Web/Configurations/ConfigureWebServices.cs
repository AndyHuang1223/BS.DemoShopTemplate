using BS.DemoShop.Web.Interfaces;
using BS.DemoShop.Web.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BS.DemoShop.Web.Configurations
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddScoped<ProductViewModelService>();
            services.AddScoped<ICatalogViewModelService, CatalogViewModelService>();
            return services;
        }
    }
}
