namespace DemoShop.Web.Models.ViewModels.Home;

public class CategoryViewModel
{
    public string Title { get; set; }
    public List<CategoryItem> CategoryItems { get; set; }
}

public class CategoryItem
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public int? ParentCategoryId { get; set; }
    public List<CategoryItem> SubCategories { get; set; }
}