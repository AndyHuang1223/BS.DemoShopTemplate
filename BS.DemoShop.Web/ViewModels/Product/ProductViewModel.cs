using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BS.DemoShop.Web.ViewModels.Product
{
    public class ProductViewModel
    {
        [Display(Name = "產品Id")]
        [Required(ErrorMessage = "必填欄位")]
        public int Id { get; set; }
        [Display(Name = "產品名稱")]
        [Required(ErrorMessage = "必填欄位")]
        public string Name { get; set; }
        [Display(Name = "產品價格")]
        public decimal Price { get; set; }
        [Display(Name = "產品主圖")]
        public string ImgPath { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public List<ProductDetailViewModel> ProductDetails { get; set; } = new List<ProductDetailViewModel>();
    }
}
