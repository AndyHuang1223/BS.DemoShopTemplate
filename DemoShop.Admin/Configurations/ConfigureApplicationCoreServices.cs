using DemoShop.ApplicationCore.Interfaces;
using DemoShop.ApplicationCore.Interfaces.TodoService;
using DemoShop.ApplicationCore.Services;
using DemoShop.Infrastructure.Data;

namespace DemoShop.Admin.Configurations;

public static class ConfigureApplicationCoreService
{
    public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services)
    {
        services.AddScoped<ITodoService, TodoService>();
        return services;
    }
}