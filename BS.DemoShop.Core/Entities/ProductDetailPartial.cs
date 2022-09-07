using System;

namespace BS.DemoShop.Core.Entities
{
    public partial class ProductDetail
    {
        public ProductDetail()
        {
            //EF Core 需要
        }

        public ProductDetail(string name, decimal unitPrice)
        {
            Name = name;
            UnitPrice = unitPrice;
            CreatedTime = DateTime.UtcNow;
        }
    }
}