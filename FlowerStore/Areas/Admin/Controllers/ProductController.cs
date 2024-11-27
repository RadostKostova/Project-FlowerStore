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

        //Display all products with pagination (handles unexisting page)
        [HttpGet]
        public async Task<IActionResult> All(int page = 1, int pageSize = 10)
        {
            var products = await productService.GetPaginatedProductsAsync(page, pageSize);

            if (page < 1 || page > products.TotalPages && products.TotalPages > 0)
            {
                return RedirectToAction(nameof(All), new { page = 1 });
            }

            return View(products);
        }

        //Display detailed product information
        [HttpGet]
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

            int modelId = await adminService.AddProductAsync(model);
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

            var model = await adminService.GetEditProductAsync(id);
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

            await adminService.PostEditProductAsync(model);
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

            var productFound = await adminService.DeleteProductAsync(id);
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

            await adminService.ConfirmDeleteAsync(product.Id);
            return RedirectToAction(nameof(All));
        }

        //Display low-stock products
        [HttpGet]
        public async Task<IActionResult> LowStockProducts()
        {
            var products = await adminService.GetLowStockProductsAsync();
            return View(products);
        }
    }
}
