using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BS.DemoShop.Web.ViewModels.Catalog
{
    public class CatalogIndexViewModel
    {
        public int? CategoryId { get; set; }
        public IEnumerable<ProductCardViewModel> ProductCards { get; set; }
        public List<SelectListItem> CategoryItemList { get; set; }
    }
}
