using System.ComponentModel.DataAnnotations;

namespace BS.DemoShop.Web.ViewModels.Account
{
    public class SignInViewModel
    {
        [Required(ErrorMessage ="必填欄位")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="請輸入有效的Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="必填欄位")]
        [Display(Name ="密碼")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
        [Display(Name = "記住我")]
        public bool IsRemember { get; set; }
    }
}
