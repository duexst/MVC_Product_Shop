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

        public IActionResult List(string category)
        {

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

            return View(new ProductListViewModel(products, _categoryRepository.AllCategories, currentCategory));
        }

        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult FilteredList(string searchString)
        {
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
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(product);
            //}

            product.Category = _categoryRepository.AllCategories.First(c => c.CategoryId == product.CategoryId);
            _productRepository.AddProduct(product);
            return RedirectToAction("List");
        }
    }
}
