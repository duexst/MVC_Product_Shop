using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MVC_Product_Shop.Models
{
    public class Product
    {
        [BindNever]
        public int ProductId { get; set; }
        [BindRequired]
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        [BindRequired]
        public decimal Price { get; set; }
        public bool IsFeaturedProduct { get; set; }
        [BindRequired]
        public int CategoryId { get; set; }
        [BindNever]
        public Category Category { get; set; } = default!;
    }
}
