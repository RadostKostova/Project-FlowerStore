using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static FlowerStore.Infrastructure.Constants.DataConstants;
using static FlowerStore.Infrastructure.Constants.ErrorConstants;

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


        [HttpGet]
        //[ShouldBeAdmin]
        public async Task<IActionResult> Add()
        {
            //should validate for Admin only
            var model = new ProductAddViewModel()
            {
                Categories = await productService.GetAllCategoriesAsync(),
            };

            return View(model);
        }

        [HttpPost]
        //[ShouldBeAdmin]
        public async Task<IActionResult> Add(ProductAddViewModel model)
        {
            //Null model validation
            if (model == null)
            {
                return BadRequest();
            }

            var categories = await productService.GetAllCategoriesAsync();

            if (!categories.Any(c => c.Id == model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "The category does not exist.");
            }

            //DateTime dateAndTime;
            //if (!DateTime.TryParseExact(model.DateAdded, DateFormatNeeded, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateAndTime))
            //{
            //    ModelState.AddModelError(nameof(model.DateAdded), errorMessage: DateFormatErrorMessage);
            //}

            var availability = await CalculateAvailability(model.FlowersCount);

            if (!ModelState.IsValid)
            {
                model.Availability = availability;
                model.Categories = categories;
                return View(model);
            }

            int modelId = await productService.AddProductAsync(model);
            return RedirectToAction(nameof(Catalog));
        }

        [HttpGet]
        //[ShouldBeAdmin]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await productService.ProductByIdExistAsync(id);

            if (product == null)
            {
                return BadRequest();
            }

            var model = await productService.GetEditProductAsync(id);
            return View(model);
        }

        [HttpPost]
        //[ShouldBeAdmin]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var categories = await productService.GetAllCategoriesAsync();
            var availability = await CalculateAvailability(model.FlowersCount);

            if (!ModelState.IsValid)
            {
                model.Categories = categories;
                model.Availability = availability;

                return View(model);
            }

            await productService.PostEditProductAsync(model);
            return RedirectToAction(nameof(Catalog));
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return RedirectToAction("Index", "Home");
            }

            var products = await productService.SearchProductAsync(searchString);

            if (products == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(products);
        }

        [HttpGet]
        //[ShouldBeAdmin]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var productId = await productService.ProductByIdExistAsync(id);

            if (productId == null)
            {
                return BadRequest();
            }

            var productFound = await productService.DeleteProductAsync(id);

            return View(productFound);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(ProductDeleteViewModel model)
        {
            var product = await productService.ProductByIdExistAsync(model.Id);

            if (product == null)
            {
                return BadRequest();
            }

            await productService.ConfirmDeleteAsync(product.Id);
            return RedirectToAction("Catalog", "Product");
        }

        //Private methods (helpers)
        private async Task<bool> CalculateAvailability(int flowerCount)
        {
            return flowerCount >= 1;
        }
    }
}
