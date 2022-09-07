using System;
using System.Collections.Generic;

namespace BS.DemoShop.Core.Entities
{
    public partial class Product
    {
        public Product()
        {
            //EF Core 需要
        }

        public Product(string productName, string imgPath, string description, ICollection<ProductDetail> details)
        {
            Name = productName;
            ImgPath = imgPath;
            Description = description;
            ProductDetailses = details;
            CreatedTime = DateTime.UtcNow;
        }
    }
}