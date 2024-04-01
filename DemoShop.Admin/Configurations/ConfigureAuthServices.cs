using System.Security.Claims;
using System.Text;
using DemoShop.Admin.Helpers;
using DemoShop.Admin.Models.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DemoShop.Admin.Configurations;

public static class ConfigureAuthServices
{
    public static IServiceCollection AddAuthServices(this IServiceCollection services)
    {
        services.AddSingleton<JwtHelper>()
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var jwtSettings = serviceProvider.GetRequiredService<IOptions<JwtSettings>>().Value;

                var issuer = jwtSettings.Issuer;
                var signKey = jwtSettings.SignKey;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // 透過這項宣告，就可以從 "sub" 取值並設定給 User.Identity.Name
                    NameClaimType = ClaimTypes.NameIdentifier,

                    // 透過這項宣告，就可以從 "ClaimTypes.Role" 取值，並可讓 [Authorize] 判斷角色
                    RoleClaimType = ClaimTypes.Role,

                    // 一般我們都會驗證 Issuer
                    ValidateIssuer = true,
                    ValidIssuer = issuer,

                    // 通常不太需要驗證 Audience
                    ValidateAudience = false,

                    // 一般我們都會驗證 Token 的有效期間
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,

                    // 如果 Token 中包含 key 才需要驗證，一般都只有簽章而已
                    ValidateIssuerSigningKey = false,

                    //如果IssuerSigningKey有設定時，ValidateIssuerSigningKey的值一定會是true，也就是會檢查SignKey的真偽
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey))
                };
            });
        return services;
    }
}