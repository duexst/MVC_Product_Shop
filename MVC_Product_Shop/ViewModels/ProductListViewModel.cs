using MVC_Product_Shop.Models;

namespace MVC_Product_Shop.ViewModels
{
	public class ProductListViewModel
	{
		public IEnumerable<Product> Products { get; }
		public IEnumerable<Category> Categories { get; }

		public string? CurrentCategory { get; }
		public string? SearchString { get; }

		public ProductListViewModel(IEnumerable<Product> products, IEnumerable<Category> categories, string? currentCategory)
		{
			Products = products;
			Categories = categories;
			CurrentCategory = currentCategory;
		}
	}
}
