using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BS.DemoShop.Admin.Filters
{
    public class DemoShopAdminAuthorize : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
                return;

            if (context.HttpContext.User.Identity?.IsAuthenticated ?? false)
                return;

            context.Result = new RedirectResult("/login");
        }
    }
}