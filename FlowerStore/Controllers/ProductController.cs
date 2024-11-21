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

        //Show all products with pagination (handles unexisting pages)
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Catalog(int page = 1, int pageSize = 8)
        {         
            var products = await productService.GetPaginatedProductsAsync(page, pageSize);

            if (page < 1)
            {
                return RedirectToAction(nameof(Catalog), new { page = 1 });
            }

            if (page > products.TotalPages && products.TotalPages > 0)
            {
                return RedirectToAction(nameof(Catalog), new { page = 1 });
            }

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
    }
}
