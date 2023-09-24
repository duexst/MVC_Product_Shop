using MVC_Product_Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MVC_Product_Shop.Models;

namespace MVC_Product_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult Index()
        {
            var productsOfTheWeek = _productRepository.FeaturedProducts;

            var homeViewModel = new HomeViewModel(productsOfTheWeek);

            return View(homeViewModel);
        }
    }
}