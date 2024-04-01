using DemoShop.Admin.Models.Settings;
using Microsoft.Extensions.Options;

namespace DemoShop.Admin.Configurations;

public static class ConfigureWebSettings
{
    public static IServiceCollection AddWebSettings(this IServiceCollection services, IConfiguration configuration)
    {

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SettingKey))
            .AddSingleton(setting => setting.GetRequiredService<IOptions<JwtSettings>>().Value);

        return services;
    }
}