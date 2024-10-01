using DemoShop.ApplicationCore.Interfaces.OrderService;
using DemoShop.ApplicationCore.Interfaces.ProductService;
using DemoShop.ApplicationCore.Interfaces;
using DemoShop.ApplicationCore.Interfaces.CatalogService;
using DemoShop.ApplicationCore.Services;
using DemoShop.Infrastructure.Data;

namespace DemoShop.Web.Configurations
{
    public static class ConfigureApplicationCoreServices
    {
        public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICatalogService, CatalogService>();

            return services;
        }
    }
}