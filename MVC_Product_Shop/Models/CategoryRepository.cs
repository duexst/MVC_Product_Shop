namespace MVC_Product_Shop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProduktShopDbContext _productShopDbContext;

        public CategoryRepository(ProduktShopDbContext produktShopDbContext) 
        {
            _productShopDbContext = produktShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _productShopDbContext.Categories.OrderBy(c => c.CategoryName);
    }
}
