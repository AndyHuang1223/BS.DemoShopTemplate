using BS.DemoShop.Core.Extensions;
using BS.DemoShop.Web.BaseModels;
using BS.DemoShop.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BS.DemoShop.Web.Filters
{
    public class ExceptionHandleAttribute : ExceptionFilterAttribute
    {


        public override void OnException(ExceptionContext context)
        {
            var result = new BaseResult
            {
                IsSuccess = false,
                Response = ApiStatus.Exception,
            };
            context.Result = new OkObjectResult(result);
        }
    }
}
