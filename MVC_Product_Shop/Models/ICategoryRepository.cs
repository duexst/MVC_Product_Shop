namespace MVC_Product_Shop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories {  get; }
    }
}
