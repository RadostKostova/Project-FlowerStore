using FlowerStore.Core.Contracts;
using FlowerStore.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Controllers
{
    /// <summary>
    /// Handles operations related to managing the shopping cart, such as adding products (flowers) to the cart, 
    /// updating quantities, removing items, and calculating the total price.
    /// </summary>
    public class ShoppingCartController : BaseController
    {
        private readonly ICartService cartService;
        private readonly IProductService productService;

        public ShoppingCartController(ICartService _cartService, IProductService _productService)
        {
            cartService = _cartService;
            productService = _productService;
        }

        //Check if cart exists - return the model if it does, else create and return
        [HttpGet]
        public async Task<IActionResult> MyShoppingCart()
        {
            string userId = User.GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            var model = await cartService.GetShoppingCartByUserIdAsync(userId);

            if (model == null)
            {
                await cartService.CreateShoppingCartAsync(userId);
                model = await cartService.GetShoppingCartByUserIdAsync(userId);
            }

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        //Add product to shopping cart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            string userId = User.GetUserId();

            if (userId == null || productId <= 0)
            {
                return BadRequest();
            }

            await cartService.AddProductToCartAsync(userId, productId, quantity);
            return RedirectToAction(nameof(MyShoppingCart));
        }

        //Remove product from shopping cart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            string userId = User.GetUserId();

            var isRemoved = await cartService.RemoveProductFromCartAsync(userId, productId);

            if (isRemoved == false)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(MyShoppingCart));
        }
    }
}
