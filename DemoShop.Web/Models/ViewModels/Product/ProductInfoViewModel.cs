namespace DemoShop.Web.Models.ViewModels.Product
{
    public class ProductInfoViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string MainPicture { get; set; }
        public string Desc { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal MinPrice { get; set; }
        public SpecVM[] Spec { get; set; }
    }
    public class SpecVM
    {
        public int SpecId { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
        public int Inventory { get; set; }
    }
}
