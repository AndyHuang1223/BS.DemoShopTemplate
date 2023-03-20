using BS.DemoShop.Infrastructure.Data;
using BS.DemoShop.Web.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BS.DemoShop.Extensions;

namespace BS.DemoShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string MyCorsPolicy = "_MyCorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //將DI放到其他組件上
            Infrastructure.Dependencies.ConfigureServices(Configuration, services);
            services.AddControllersWithViews();
            services.AddCoreServices();
            services.AddWebServices();
            services.AddCookieSettings();
            services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BS.DemoShopTemplate API",
                    Description = "描述...",
                });
                
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
            
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyCorsPolicy,
                    policy =>
                    {
                        policy.AllowAnyOrigin() //TODO 依據需求調整Cors來源
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                    });
            });

            services.AddMemoryCache();
            
            //分散式快取，Redis
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("RedisConnectionString");
                options.InstanceName = "MyRedisCache";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BS.DemoShopTemplate API v1"));
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(MyCorsPolicy);

            app.UseAuthentication();
            app.UseAuthorization();
            
            //不給Google爬蟲爬到的Response處理，https://developers.google.com/search/docs/advanced/crawling/block-indexing?hl=zh-tw#http-response-header
            app.UseNoIndexResponse();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(name: "Index", pattern: "/", new { Controller = "Product", Action = "CatalogIndex" });
                endpoints.MapControllerRoute(name: "SignIn", pattern: "signin", new { Controller = "Account", Action = "SignIn" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
