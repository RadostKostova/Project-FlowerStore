using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ProductAddViewModel()
            {
                Categories = await productService.GetAllCategoriesAsync(),
            };

            return View(model);
        }

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
            //return RedirectToAction(nameof(Catalog));
            return RedirectToAction("Catalog", "Product", new { area = "" });
        }


        //Private methods (helpers)
        private async Task<bool> CalculateAvailability(int flowerCount)
        {
            return flowerCount >= 1;
        }
    }
}
