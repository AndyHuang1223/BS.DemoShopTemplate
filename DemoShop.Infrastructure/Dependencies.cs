using DemoShop.ApplicationCore.Interfaces;
using DemoShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoShop.Infrastructure;

public static class Dependencies
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BSDemoShopContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("BSDemoShopConnection")));
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped<IUnitOfWork, EfUnitOfWorkByServiceProvider>();
    }
}