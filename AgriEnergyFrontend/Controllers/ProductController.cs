using AgriFrontend.Model;
using AgriFrontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgriEnergyFrontend.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _productService.GetAllProductsAsync();
            return View(products);
        }
    }
}