using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.ApplicationCore.Interfaces.ProductService.Dto
{
    public class GetProductInfoOutput
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string MainPicture { get; set; }
        public string Desc { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal MinPrice { get; set; }
        public ProductInfoSpec[] Spec { get; set; }
    }

    public class ProductInfoSpec
    {
        public int SpecId { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
        public int Inventory { get; set; }
    }


}
