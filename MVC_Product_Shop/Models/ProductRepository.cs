using Microsoft.EntityFrameworkCore;

namespace MVC_Product_Shop.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProduktShopDbContext _productShopDbContext;

        public ProductRepository(ProduktShopDbContext productShopDbContext)
        {
            _productShopDbContext = productShopDbContext;
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return _productShopDbContext.Products.Include(p => p.Category);
            }
        }

        public IEnumerable<Product> FeaturedProducts
        {
            get
            {
                return _productShopDbContext.Products.Include(p => p.Category).Where(p => p.IsFeaturedProduct);
            }
        }

        public Product? GetProductById(int productId)
        {
            return _productShopDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        public IEnumerable<Product> GetProductsForCategory(string categoryName)
        {
            return _productShopDbContext.Products.Where(p => p.Category.CategoryName == categoryName);
        }

        public IEnumerable<Product> SearchProducts(string searchQuery)
        {
            return _productShopDbContext.Products.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
