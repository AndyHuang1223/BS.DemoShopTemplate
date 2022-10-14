using BS.DemoShop.Admin.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace BS.DemoShop.Admin.Configurations
{
    public static class ConfigureWebService
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddScoped<CustomApiExceptionServiceFilter>();
            services.AddScoped<DemoShopAdminAuthorize>();
            return services;
        }
    }
}