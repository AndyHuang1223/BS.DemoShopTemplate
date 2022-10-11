using BS.DemoShop.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace BS.DemoShop.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseNoIndexResponse(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NoIndexResponseMiddleware>();
        }
    }
}