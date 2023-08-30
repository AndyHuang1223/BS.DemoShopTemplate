using DemoShop.Web.Services.Cms;
using DemoShop.Web.Services;

namespace DemoShop.Web.Configurations
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddScoped<ICmsViewModelService, CmsService>();

            services.AddScoped<ProductViewModelService>();

            return services;
        }
    }
}
