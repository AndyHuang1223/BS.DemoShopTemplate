using System;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using BS.DemoShop.Admin.Helpers;
using BS.DemoShop.Core.Interfaces;
using BS.DemoShop.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BS.DemoShop.Admin.Configurations
{
    public static class ConfigureJwtService
    {
        public static IServiceCollection AddJwtServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton<JwtHelper>()
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // 透過這項宣告，就可以從 "sub" 取值並設定給 User.Identity.Name
                        NameClaimType = ClaimTypes.NameIdentifier,

                        // 透過這項宣告，就可以從 "ClaimTypes.Role" 取值，並可讓 [Authorize] 判斷角色
                        RoleClaimType = ClaimTypes.Role,

                        // 一般我們都會驗證 Issuer
                        ValidateIssuer = true,
                        ValidIssuer = configuration.GetValue<string>("JwtSettings:Issuer"),

                        // 通常不太需要驗證 Audience
                        ValidateAudience = false,

                        // 一般我們都會驗證 Token 的有效期間
                        ValidateLifetime = true,

                        // 如果 Token 中包含 key 才需要驗證，一般都只有簽章而已
                        ValidateIssuerSigningKey = false,

                        //如果IssuerSigningKey有設定時，ValidateIssuerSigningKey的值一定會是true，也就是會檢查SignKey的真偽
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JwtSettings:SignKey")))
                    };
                });

            return services;
        }
    }
}       