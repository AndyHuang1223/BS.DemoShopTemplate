using DemoShop.Web.Services.CmsService;
using DemoShop.Web.Services.ProductService;

namespace DemoShop.Web.Configurations
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddScoped<ICmsViewModelService, CmsService>();

            services.AddScoped<ProductViewModelService>();
            services.AddScoped<ICategoryViewModelService, CategoryViewModelService>();

            return services;
        }
    }
}