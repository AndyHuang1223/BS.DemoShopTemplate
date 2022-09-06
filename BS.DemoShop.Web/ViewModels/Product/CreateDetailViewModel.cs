using System.ComponentModel.DataAnnotations;

namespace BS.DemoShop.Web.ViewModels.Product
{
    public class CreateDetailViewModel
    {
        [Required(ErrorMessage = "必填欄位")]
        [Display(Name = "規格名稱")]
        public string SpecName { get; set; }

        [Required(ErrorMessage = "必填欄位")]
        [Display(Name = "單價")]
        public decimal UnitPrice { get; set; }

        public int ProductId { get; set; }
    }
}
