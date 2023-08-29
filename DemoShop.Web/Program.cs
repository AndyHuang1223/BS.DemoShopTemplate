using DemoShop.ApplicationCore.Interfaces;
using DemoShop.ApplicationCore.Interfaces.OrderService;
using DemoShop.ApplicationCore.Interfaces.ProductService;
using DemoShop.ApplicationCore.Services;
using DemoShop.Infrastructure.Data;
using DemoShop.Web.Services.Cms;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DemoShop.Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

//TODO 抽換成Configurations(為服務群組註冊擴充方法)
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>(); 
builder.Services.AddScoped<FakeCmsViewModelService, FakeCmsViewModelService>();

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