namespace DemoShop.ApplicationCore.Entities;

public class Catalog : BaseEntity
{
    public string Name { get; set; }
    public int? ParentCatalogId { get; set; }
    public Catalog ParentCatalog { get; set; }
}