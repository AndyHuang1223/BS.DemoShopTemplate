using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Core.Entities
{
    public partial class ProductDetail : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Inventory { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset? UpdatedTime { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
