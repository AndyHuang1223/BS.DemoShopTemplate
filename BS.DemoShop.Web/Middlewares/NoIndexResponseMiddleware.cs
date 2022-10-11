using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BS.DemoShop.Middlewares
{
    public class NoIndexResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public NoIndexResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("X-Robots-Tag", "noindex");

            await _next(httpContext);
        }
    }
}