using System.ComponentModel.DataAnnotations;

namespace BS.DemoShop.Web.ViewModels
{
    public class ProductDetailViewModel
    {
        [Display(Name = "規格Id")]
        [Required(ErrorMessage = "必填欄位")]
        public int Id { get; set; }
        [Display(Name = "規格名稱")]
        [Required(ErrorMessage = "必填欄位")]
        public string Name { get; set; }
        [Display(Name = "單價")]
        [Required(ErrorMessage = "必填欄位")]
        public decimal UnitPrice { get; set; }
    }
}
