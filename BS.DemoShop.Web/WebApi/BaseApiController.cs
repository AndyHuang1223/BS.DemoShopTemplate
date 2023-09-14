using BS.DemoShop.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BS.DemoShop.Web.WebApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ExceptionHandle]
    public abstract class BaseApiController : ControllerBase
    {
       
    }
}
