using MVC_Product_Shop.Models;

namespace MVC_Product_Shop.ViewModels
{
    public class ProductAddViewModel
    {
        public Product? Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public ProductAddViewModel(IEnumerable<Category> category) 
        {
            Categories = category;
            Product = new Product();
        }
    }
}
