using BS.DemoShop.Web.Interfaces;
using BS.DemoShop.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BS.DemoShop.Web.Configurations
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddScoped<ProductViewModelService>();
            services.AddScoped<ICatalogViewModelService, CatalogViewModelService>();
            services.AddScoped<IAccountViewModelService, AccountViewModelService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
