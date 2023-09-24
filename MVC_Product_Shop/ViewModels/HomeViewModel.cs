using MVC_Product_Shop.Models;

namespace MVC_Product_Shop.ViewModels
{
	public class HomeViewModel
	{
		public IEnumerable<Product> FeaturedProducts { get; }

		public HomeViewModel(IEnumerable<Product> featuredProducts)
		{
			FeaturedProducts = featuredProducts;
		}
	}
}
