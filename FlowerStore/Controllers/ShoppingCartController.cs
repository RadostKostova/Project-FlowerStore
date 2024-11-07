using FlowerStore.Core.Contracts;
using FlowerStore.Extensions;
using Microsoft.AspNetCore.Authorization;
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

        //Get view of shopping cart
        [HttpGet]
        public async Task<IActionResult> MyShoppingCart()
        {
            string userId = User.GetUserId();

            if (userId == null)
            {
                return BadRequest();
            }

            //var cart = await cartService.GetOrCreateShoppingCartAsync(userId);
            var model = await cartService.ViewShoppingCartAsync(userId);

            return View(model);
        }

        //Add product to shopping cart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            string userId = User.GetUserId();

            if (userId == null)
            {
                return BadRequest();
            }

            if (productId <= 0 || quantity <= 0)
            {
                return BadRequest();
            }

            var isProductAdded = await cartService.AddProductToCartAsync(userId, productId, quantity);

            if (isProductAdded == false)
            {
                return BadRequest();
            }

            return RedirectToAction("Catalog", "Product");
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

            return RedirectToAction("MyShoppingCart", "ShoppingCart");
        }

    }
}
