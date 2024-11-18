using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Areas.Admin.Controllers
{
    /// <summary>
    /// This controller manages product operations for Admin area
    /// </summary>
     
    public class ProductController : AdminBaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        //Display all products
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await productService.ShowAllProductsAsync();
            return View(products);
        }

        //Get add form
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ProductAddViewModel()
            {
                Categories = await productService.GetAllCategoriesAsync(),
            };

            return View(model);
        }

        //Add product to database
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel model)
        {
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
            return RedirectToAction(nameof(All));
        }

        //Get edit form
        [HttpGet]
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

        //Edit product and save to database
        [HttpPost]
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
            return RedirectToAction(nameof(All));
        }

        //Get delete form
        [HttpGet]
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

        //Delete product from database
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(ProductDeleteViewModel model)
        {
            var product = await productService.ProductByIdExistAsync(model.Id);

            if (product == null)
            {
                return BadRequest();
            }

            await productService.ConfirmDeleteAsync(product.Id);
            return RedirectToAction(nameof(All));
        }


        //Private methods (helpers)
        private async Task<bool> CalculateAvailability(int flowerCount)
        {
            return flowerCount >= 1;
        }
    }
}
