namespace MVC_Product_Shop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductShopDbContext _productShopDbContext;

        public CategoryRepository(ProductShopDbContext produktShopDbContext) 
        {
            _productShopDbContext = produktShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _productShopDbContext.Categories.OrderBy(c => c.CategoryName);
    }
}
