using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Core.Entities
{
    public partial class Category : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public DateTimeOffset CreatedTime { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
