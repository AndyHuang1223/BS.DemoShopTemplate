namespace DemoShop.ApplicationCore.Interfaces.CatalogService.Dto;

public class CatalogItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentCatalogId { get; set; }
    public List<CatalogItem> SubCatalog { get; set; }
}