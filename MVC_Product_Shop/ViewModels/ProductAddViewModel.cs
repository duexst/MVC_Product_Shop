using MVC_Product_Shop.Models;

namespace MVC_Product_Shop.ViewModels
{
    public class ProductAddViewModel
    {
        public string? ProductName { get; set; }
        public int? Price { get; set; }
        public string? Description { get; set; }
        public bool IsFeaturedProduct { get; set; } = false;
        public IEnumerable<Category> Categories { get; set; }
        public Category SelectedCategory { get; set; }

        public ProductAddViewModel(IEnumerable<Category> category) 
        {
            Categories = category;
        }
    }
}
