using System.IO.Pipelines;

namespace MVC_Product_Shop.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Product Product);
        int RemoveFromCart(Product Product);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
