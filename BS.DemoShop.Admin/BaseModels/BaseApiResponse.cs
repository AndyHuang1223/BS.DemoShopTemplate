using BS.DemoShop.Admin.Enums;
using BS.DemoShop.Core.Helpers;

namespace BS.DemoShop.Admin.BaseModels
{
    public class BaseApiResponse
    {
        public BaseApiResponse()
        {
            
        }

        public BaseApiResponse(object body)
        {
            IsSuccess = true;
            Code = ApiStatusEnum.Success;
            Body = body;
        }
        public bool IsSuccess { get; set; }
        public object Body { get; set; }
        public string Message => EnumHelper<ApiStatusEnum>.GetDisplayValue(Code);
        public ApiStatusEnum Code { get; set; }
    }
}