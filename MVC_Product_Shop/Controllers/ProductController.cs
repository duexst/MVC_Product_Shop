using Microsoft.AspNetCore.Mvc;
using MVC_Product_Shop.Models;
using MVC_Product_Shop.ViewModels;
using System.Diagnostics;

namespace MVC_Product_Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private Stopwatch _stopwatch;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _stopwatch = new Stopwatch();
        }

        public IActionResult List(string category)
        {
            _stopwatch.Restart();
            IEnumerable<Product> products;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                products = _productRepository.AllProducts.OrderBy(p => p.ProductId);
                currentCategory = "All products";
            }
            else
            {
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
                products = _productRepository.GetProductsForCategory(currentCategory);
            }

            _stopwatch.Stop();
            return View(new ProductListViewModel(products, _categoryRepository.AllCategories, currentCategory));
        }

        public IActionResult Details(int id)
        {
            _stopwatch.Restart();
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            _stopwatch.Stop();
            return View(product);
        }

        public IActionResult FilteredList(string searchString)
        {
            _stopwatch.Restart();
            IEnumerable<Product> products;
            string currentCategory = "All products";

            if (string.IsNullOrEmpty(searchString))
            {
                products = _productRepository.AllProducts.OrderBy(p => p.ProductId);
            }
            else
            {
                products = _productRepository.SearchProducts(searchString);
            }
            _stopwatch.Stop();
            return View("List", new ProductListViewModel(products, _categoryRepository.AllCategories, currentCategory));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ProductAddViewModel(_categoryRepository.AllCategories));
        }

        [HttpPost]
        public IActionResult Add(Product product) 
        {
            _stopwatch.Restart();
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(product);
            //}

            product.Category = _categoryRepository.AllCategories.First(c => c.CategoryId == product.CategoryId);
            _productRepository.AddProduct(product);

            _stopwatch.Stop();
            return RedirectToAction("List");            
        }
    }
}
