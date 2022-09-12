using BS.DemoShop.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BS.DemoShop.Web.ViewModels.Account
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="必填欄位")]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "必填欄位")]
        [Display(Name = "帳號(Email)")]
        [EmailAddress(ErrorMessage ="請輸入Email格式")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "必填欄位")]
        [Display(Name="密碼")]
        public string Password { get; set; }

        [Required(ErrorMessage = "必填欄位")]
        [Display(Name="確認密碼")]
        public string ConfirmPassword { get; set; }

        public List<SelectListItem> GenderList { get; set; }

        public string ReturnUrl { get; set; }
        public UserGender? Gender { get; set; }

    }
}
