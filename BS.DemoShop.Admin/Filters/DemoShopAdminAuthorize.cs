using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BS.DemoShop.Admin.Filters
{
    public class DemoShopAdminAuthorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
            {
                return;
            }

            if (context.HttpContext.User.Identity?.IsAuthenticated ?? false)
            {
                ////TODO 登出後jti失效Filter(不能再登入，要取得新的)
                //var jti = context.HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                return;
            }

            context.Result = new ForbidResult();
        }
    }
}