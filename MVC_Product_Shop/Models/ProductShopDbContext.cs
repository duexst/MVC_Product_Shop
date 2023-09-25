using Microsoft.EntityFrameworkCore;

namespace MVC_Product_Shop.Models
{
    public class ProductShopDbContext : DbContext
    {
        public ProductShopDbContext(DbContextOptions<ProductShopDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set;}
    }
}
