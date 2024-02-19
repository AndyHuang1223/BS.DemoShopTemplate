using DemoShop.ApplicationCore.Interfaces.OrderService;
using DemoShop.ApplicationCore.Interfaces.ProductService;
using DemoShop.ApplicationCore.Interfaces;
using DemoShop.ApplicationCore.Services;
using DemoShop.Infrastructure.Data;

namespace DemoShop.Web.Configurations
{
    public static class ConfigureApplicationCoreServices
    {
        public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services)
        {
            //TODO 抽換成Configurations(為服務群組註冊擴充方法)
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();


            return services;
        }
    }
}
