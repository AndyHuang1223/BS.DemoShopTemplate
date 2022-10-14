using System.ComponentModel.DataAnnotations;

namespace BS.DemoShop.Admin.Enums
{
    public enum ApiStatusEnum
    {
        [Display(Name = "成功")]Success = 0,
        [Display(Name = "未登入")]NotAuth = 401,
        [Display(Name = "找不到")]NotFound = 404,
        [Display(Name = "建立失敗")]CreateFailure = 455,
        [Display(Name = "發生例外")]Exception = 999
    }
}