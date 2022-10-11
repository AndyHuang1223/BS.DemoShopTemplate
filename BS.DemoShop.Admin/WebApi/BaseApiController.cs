using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BS.DemoShop.Admin.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BS.DemoShop.Admin.WebApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ServiceFilter(typeof(CustomApiExceptionServiceFilter))]
    [Authorize]
    public abstract class BaseApiController : ControllerBase
    {
    }
}