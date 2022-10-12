using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using BS.DemoShop.Core.Entities;
using BS.DemoShop.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BS.DemoShop.Admin.Filters
{
    public class DemoShopAdminAuthorize : Attribute, IAuthorizationFilter
    {
        private readonly IRepository<BlockToken> _blockToken;

        public DemoShopAdminAuthorize(IRepository<BlockToken> blockToken)
        {
            _blockToken = blockToken;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
            {
                return;
            }

            if (context.HttpContext.User.Identity?.IsAuthenticated ?? false)
            {
                //登出後Token失效Filter(不能再登入，要取得新的)
                var authorization = context.HttpContext.Request.Headers["Authorization"];
                var token = authorization.ToString().Split("bearer ").Last();
                if (!_blockToken.Any(x => x.Token.ToLower() == token.ToLower()))
                {
                    return;
                }
            }

            context.Result = new ForbidResult();
        }
    }
}