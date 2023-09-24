using Microsoft.EntityFrameworkCore;

namespace MVC_Product_Shop.Models
{
    public class ProduktShopDbContext : DbContext
    {
        public ProduktShopDbContext(DbContextOptions<ProduktShopDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
