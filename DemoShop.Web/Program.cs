
using DemoShop.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DemoShop.Infrastructure.Dependencies.ConfigureServices(builder.Services, builder.Configuration);

builder.Services
    .AddApplicationCoreServices()
    .AddWebServices(builder.Configuration);

builder.Services.AddMemoryCache();

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