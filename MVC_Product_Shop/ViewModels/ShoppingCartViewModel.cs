using MVC_Product_Shop.Models;

namespace MVC_Product_Shop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IShoppingCart ShoppingCart { get; }
        public decimal ShoppingCartTotal { get; }
        public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal shoppingCartTotal)
        {
            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCartTotal;
        }
    }
}
