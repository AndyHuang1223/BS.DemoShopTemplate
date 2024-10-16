using DemoShop.Web.CacheServices;
using DemoShop.Web.Services.CmsService;
using DemoShop.Web.Services.ProductService;

namespace DemoShop.Web.Configurations
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICmsViewModelService, CmsService>();

            services.AddScoped<ProductViewModelService>();

            // services.AddScoped<ICategoryViewModelService, MemoryCacheCategoryService>();
            services.AddScoped<CategoryViewModelService>();    //注入後給MemoryCacheCategoryService用
            services.AddMemoryCache();    //啟用記憶體內部快取(安裝的套件`Microsoft.Extensions.Caching.Memory`)

            services.AddScoped<ICategoryViewModelService, RedisCacheCategoryViewModelService>();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
                options.InstanceName = "DemoShop-Cache";
            });
            return services;
        }
    }
}
