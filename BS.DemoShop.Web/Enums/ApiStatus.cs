using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BS.DemoShop.Web.Enums
{
    /// <summary>
    /// 自訂API Status Code以及對應的Enum
    /// </summary>
    public enum ApiStatus
    {
        [Display(Name = "成功")] Success = 0,
        [Display(Name = "未找到")] NotFound = 404,
        [Display(Name = "執行時發生 Exception")] Exception = 999
        //TODO 視情況新增對應的Enum
    }
}
