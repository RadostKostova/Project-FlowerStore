using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Product;
using FlowerStore.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Controllers
{
    /// <summary>
    /// Manages operations related to displaying products (flowers), such as listing all flowers, displaying details of a specific flower 
    /// and searching for flowers based on criteria like category, name, or else.
    /// </summary>
    
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Catalog()
        {
            var products = await productService.ShowAllProductsAsync();
            return View(products);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int productId) 
        {
            var productFound = await productService.ProductByIdExistAsync(productId);

            if (productFound == null || ModelState.IsValid == false)
            {
                return BadRequest(); //should create Error Page later
            }

            var model = await productService.GetProductDetailsAsync(productFound.Id);

            return View(model);
        }
    }
}
