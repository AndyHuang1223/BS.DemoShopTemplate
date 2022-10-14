using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BS.DemoShop.Core.Interfaces;
using BS.DemoShop.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BS.DemoShop.Admin.Configurations
{
    public static class ConfigureSwaggerService
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {

            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BS.DemoShopTemplate Admin API",
                    Description = "描述...",
                });
                
                                // swagger �[�J jwt �䴩
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    { new OpenApiSecurityScheme(){ }, new List<string>() }
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
                
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
            
            return services;
        }
    }
}       