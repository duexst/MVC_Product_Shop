using Microsoft.AspNetCore.Mvc;
using MVC_Product_Shop.Models;
using MVC_Product_Shop.ViewModels;

namespace MVC_Product_Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            ProductListViewModel productListViewModel = new(_productRepository.AllProducts, "Toys");
            return View(productListViewModel);
        }

        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if(product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
