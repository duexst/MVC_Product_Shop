using System.IO.Pipelines;

namespace MVC_Product_Shop.Models
{
	public static class DbInitializer
	{
		public static void Seed(IApplicationBuilder applicationBuilder)
		{
			ProduktShopDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ProduktShopDbContext>();

			if (!context.Categories.Any())
			{
				context.Categories.AddRange(Categories.Select(c => c.Value));
			}

			if (!context.Products.Any())
			{
				context.AddRange
				(
					new Product { Name = "Lego Truck", Price = 22.95M, ShortDescription = "Yellow lego truck", LongDescription = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren", Category = Categories["Toys"], InStock = true, IsFeaturedProduct = true},
					new Product { Name = "Lightsaber", Price = 49.99M, ShortDescription = "Toy lightsaber", LongDescription = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren", Category = Categories["Toys"], InStock = true, IsFeaturedProduct = true},
					new Product { Name = "Chocolate Cake", Price = 10.95M, ShortDescription = "Dark chocolate cake", LongDescription = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren", Category = Categories["Food"], InStock = true, IsFeaturedProduct = true},
					new Product { Name = "Brezel", Price = 1.49M, ShortDescription = "Salted brezel", LongDescription = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren", Category = Categories["Food"], InStock = true, IsFeaturedProduct = true},
					new Product { Name = "Marmelade", Price = 3.95M, ShortDescription = "Super tasty marmelade", LongDescription = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren", Category = Categories["Food"], InStock = true, IsFeaturedProduct = true},
					new Product { Name = "Hammer", Price = 22.95M, ShortDescription = "Sturdy hammer", LongDescription = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren", Category = Categories["Tools"], InStock = true, IsFeaturedProduct = true},
					new Product { Name = "Handsaw", Price = 34.95M, ShortDescription = "Great quality saw", LongDescription = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren", Category = Categories["Tools"], InStock = true, IsFeaturedProduct = true},
					new Product { Name = "Drill", Price = 288.95M, ShortDescription = "Best drill", LongDescription = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren", Category = Categories["Tools"], InStock = true, IsFeaturedProduct = true},
					new Product { Name = "T-Shirt", Price = 22.95M, ShortDescription = "Stylish t-short for cool ppl", LongDescription = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren", Category = Categories["Clothing"], InStock = true, IsFeaturedProduct = true},
					new Product { Name = "Jeans", Price = 99.95M, ShortDescription = "Super cool jeans", LongDescription = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren", Category = Categories["Clothing"], InStock = true, IsFeaturedProduct = true},
					new Product { Name = "Pullover", Price = 69.95M, ShortDescription = "Drippy pullover", LongDescription = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren", Category = Categories["Clothing"], InStock = true, IsFeaturedProduct = true}
				);
			}

			context.SaveChanges();
		}

		private static Dictionary<string, Category>? categories;
		public static Dictionary<string, Category> Categories
		{
			get
			{
				if (categories == null)
				{
					var genresList = new Category[]
					{
						new Category { CategoryName = "Food" },
						new Category { CategoryName = "Toys" },
						new Category { CategoryName = "Tools" },
						new Category { CategoryName = "Clothing" }
					};

					categories = new Dictionary<string, Category>();

					foreach (Category genre in genresList)
					{
						categories.Add(genre.CategoryName, genre);
					}
				}

				return categories;
			}
		}
	}
}
