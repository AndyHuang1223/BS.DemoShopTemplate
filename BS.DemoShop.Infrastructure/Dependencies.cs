using BS.DemoShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BS.DemoShop.Infrastructure
{
    public class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<BSDemoShopContext>(options => options.UseSqlServer(configuration.GetConnectionString("BSDemoShopConnection")));
        }
    }
}