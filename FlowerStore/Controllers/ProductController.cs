using FlowerStore.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Controllers
{
    /// <summary>
    /// Manages operations related to products (flowers) for users
    /// </summary>

    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        //Show all products
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Catalog()
        {
            var products = await productService.ShowAllProductsAsync();
            return View(products);
        }

        //Get details of product
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var productFound = await productService.ProductByIdExistAsync(id);

            if (productFound == null || ModelState.IsValid == false)
            {
                return BadRequest(); //should create Error Page later
            }

            var model = await productService.GetProductDetailsAsync(productFound.Id);

            return View(model);
        }

        //Search product
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Search(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return RedirectToAction("Index", "Home");
            }

            var products = await productService.SearchProductAsync(searchString);

            return View(products);
        }

        //Private methods (helpers)
        private async Task<bool> CalculateAvailability(int flowerCount)
        {
            return flowerCount >= 1;
        }
    }
}
