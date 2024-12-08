using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Cart;
using FlowerStore.Core.ViewModels.CartProduct;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data.Models.Cart;
using FlowerStore.Infrastructure.Data.Models.Carts;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Core.Services
{
    /// <summary>
    /// Shopping Cart services implemented. Handles id finding, existing, add or remove product from cart, clear and etc.
    /// </summary>

    public class CartService : ICartService
    {
        private readonly IRepository repository;
        private readonly IProductService productService;

        public CartService(IRepository _repository,
            IProductService _productService)
        {
            repository = _repository;
            productService = _productService;
        }

        //Check cart existance by userId and return as entity
        public async Task<ShoppingCart> ShoppingCartExistByUserIdAsync(string userId)
        {
            var cart = await repository
                .All<ShoppingCart>()
                .Include(sc => sc.ShoppingCartProducts)
                .ThenInclude(scp => scp.Product)
                .FirstOrDefaultAsync(sc => sc.UserId == userId);

            return cart;
        }

        //Get cart as viewModel
        public async Task<CartViewModel> GetShoppingCartByUserIdAsync(string userId)
        {
            var cart = await repository
                .AllAsReadOnly<ShoppingCart>()
                .Include(sc => sc.ShoppingCartProducts)
                .ThenInclude(scp => scp.Product)
                .FirstOrDefaultAsync(sc => sc.UserId == userId);

            if (cart == null)  
            {
                return null; 
            }

            var categories = await productService.GetAllCategoriesAsync();

            var model = new CartViewModel()
            {
                Id = cart.Id,
                UserId = userId,
                ProductsCounter = cart.ShoppingCartProducts.Sum(p => p.Quantity),
                TotalPrice = cart.TotalPrice,
                ShoppingCartProducts = cart.ShoppingCartProducts.Select(scp => new CartProductViewModel()
                {
                    ProductId = scp.ProductId,
                    Name = scp.Product.Name,
                    Quantity = scp.Quantity,
                    UnitPrice = scp.Price,
                    ImageUrl = scp.Product.ImageUrl,
                    Category = categories.FirstOrDefault(c => c.Id == scp.Product.CategoryId).Name
                }).ToList()
            };
            return model;
        }

        //Creates a new shopping cart in database
        public async Task<ShoppingCart> CreateShoppingCartAsync(string userId)
        {
            var newCart = new ShoppingCart
            {
                UserId = userId,
                ProductsCounter = 0,
                TotalPrice = 0,
                ShoppingCartProducts = new List<ShoppingCartProduct>()
            };

            await repository.AddAsync(newCart);
            await repository.SaveChangesAsync();
            return newCart;
        }        

        //Add a product to the shopping cart (if cart doesnt exist - create it)
        public async Task AddProductToCartAsync(string userId, int productId, int quantity)
        {
            var cart = await ShoppingCartExistByUserIdAsync(userId);

            if (cart == null) 
            {
                cart = await CreateShoppingCartAsync(userId); 
            }

            var productInCart = cart.ShoppingCartProducts.FirstOrDefault(p => p.ProductId == productId);

            if (productInCart != null)
            {
                productInCart.Quantity += quantity;
            }
            else
            {
                var productPrice = (decimal)await productService.GetProductPriceAsync(productId);

                var newProductInCart = new ShoppingCartProduct
                {
                    ProductId = productId,
                    Quantity = quantity,
                    ShoppingCartId = cart.Id,
                    Price = productPrice
                };

                cart.ShoppingCartProducts.Add(newProductInCart);             
            };

            cart.TotalPrice += (decimal)(await productService.GetProductPriceAsync(productId)) * quantity;
            cart.ProductsCounter += quantity;

            await repository.SaveChangesAsync();
        }

        //Remove product from shopping cart
        public async Task<bool> RemoveProductFromCartAsync(string userId, int productId)
        {
            var cart = await ShoppingCartExistByUserIdAsync(userId);

            if (cart == null)
            {
                return false;
            }

            var product = cart.ShoppingCartProducts.FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                return false;
            }

            cart.TotalPrice -= product.Price * product.Quantity;
            cart.ProductsCounter -= product.Quantity;

            await repository.RemoveAsync(product);
            await repository.SaveChangesAsync();
            return true;
        }

        //Get specific product in cart
        public async Task<CartProductViewModel> GetProductInCartByIdAsync(int cartId, int productId)
        {
            var product = await repository
                .AllAsReadOnly<ShoppingCartProduct>()
                .Include(scp => scp.Product)
                .Where(scp => scp.ShoppingCartId == cartId && scp.ProductId == productId)
                .Select(scp => new CartProductViewModel()
                {
                    ProductId = scp.ProductId,
                    Name = scp.Product.Name,
                    Quantity = scp.Quantity,
                    UnitPrice = scp.Price,
                    ImageUrl = scp.Product.ImageUrl
                })
                .FirstOrDefaultAsync();

            return product;
        }

        //Clear shopping cart products
        public async Task ClearCartAsync(string userId)
        {
            var cart = await ShoppingCartExistByUserIdAsync(userId);

            if (cart != null && cart.ProductsCounter != 0)
            {
                cart.ShoppingCartProducts.Clear();
                cart.TotalPrice = 0;
                cart.ProductsCounter = 0;
                await repository.SaveChangesAsync();
            }
        }

        //Check if cart contains any products
        public async Task<bool> IsShoppingCartEmpty(string userId)
        {
            var cart = await GetShoppingCartByUserIdAsync(userId);

            return !cart.ShoppingCartProducts.Any();
        }      
    }
}