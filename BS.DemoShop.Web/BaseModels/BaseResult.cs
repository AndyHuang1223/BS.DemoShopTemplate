using BS.DemoShop.Core.Helpers;
using BS.DemoShop.Web.Enums;
using System;

namespace BS.DemoShop.Web.BaseModels
{
    public class BaseResult
    {
        public BaseResult()
        {
            IsSuccess = true;
            Response = ApiStatus.Success;
        }
        public object Body { get; set; }
        public bool IsSuccess { get; set; }
        public ApiStatus Response { get; set; }
        public string Code => Convert.ToInt32(Response).ToString().PadLeft(3, '0');
        public string Message => EnumHelper<ApiStatus>.GetDisplayValue(Response);
    }
}
