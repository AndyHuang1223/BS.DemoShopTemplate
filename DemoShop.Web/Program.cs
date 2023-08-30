using DemoShop.ApplicationCore.Interfaces;
using DemoShop.ApplicationCore.Interfaces.OrderService;
using DemoShop.ApplicationCore.Interfaces.ProductService;
using DemoShop.ApplicationCore.Services;
using DemoShop.Infrastructure.Data;
using DemoShop.Web.Services.Cms;
using DemoShop.Web.Services;
using DemoShop.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DemoShop.Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

builder.Services
    //.AddApplicationCoreServices()
    .AddWebServices();


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();