using BS.DemoShop.Web.Interfaces;
using BS.DemoShop.Web.Services;
using BS.DemoShop.Web.Services.CacheServices;
using BS.DemoShop.Web.Services.TodoService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BS.DemoShop.Web.Configurations
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddScoped<ProductViewModelService>();
            // services.AddScoped<ICatalogViewModelService, CatalogViewModelService>();
            // services.AddScoped<ICatalogViewModelService, MemoryCacheCatalogViewModelService>();
            services.AddScoped<ICatalogViewModelService, DistributedCacheCatalogViewModelService>();
            services.AddScoped<CatalogViewModelService>();
            
            services.AddScoped<IAccountViewModelService, AccountViewModelService>();
            services.AddScoped<ISingInManager, CustomSingInManager>();
            services.AddScoped<ITodoService, TodoService>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
