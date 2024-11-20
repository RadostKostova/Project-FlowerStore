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
        private readonly IAdminService adminService;

        public ProductController(IProductService _productService,
            IAdminService _adminService)
        {
            productService = _productService;
            adminService = _adminService;
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

            if (!ModelState.IsValid)
            {
                model.Categories = await productService.GetAllCategoriesAsync();
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

            if (!ModelState.IsValid)
            {
                model.Categories = await productService.GetAllCategoriesAsync();
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

        [HttpGet]
        public async Task<IActionResult> LowStockWarning()   //TODO
        {
            var lowStockProducts = await adminService.GetLowStockProductsAsync();

            if (!lowStockProducts.Any())
            {
                return Ok("All products are sufficiently stocked.");
            }

            var warnings = lowStockProducts
                .Select(p => $"{p.Name} has only {p.FlowersCount} left in stock.")
                .ToList();

            return View(warnings); // Or return as JSON, depending on the scenario
        }
    }
}
