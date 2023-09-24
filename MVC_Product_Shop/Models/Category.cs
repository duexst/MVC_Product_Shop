using System.IO.Pipelines;

namespace MVC_Product_Shop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = "";
        public string? Description { get; set; }
        public List<Product>? Pies { get; set; }
    }
}
