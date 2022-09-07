using System.ComponentModel.DataAnnotations;

namespace BS.DemoShop.Web.ViewModels.Product
{
    public class CreateDefaultProductDTO
    {
        [Required(ErrorMessage = "必填欄位")]
        [Display(Name = "商品名稱")]
        public string Name { get; set; }

        [Display(Name = "圖片路徑")]
        public string ImgPath { get; set; }
        
    }
}