using DemoShop.Admin.Helpers;
using DemoShop.Admin.Services;

namespace DemoShop.Admin.Configurations;

public static class ConfigureWebServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddScoped<UserMangerService>();
        return services;
    }
}