using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Cart;
using FlowerStore.Core.ViewModels.CartProduct;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data.Models.Cart;
using FlowerStore.Infrastructure.Data.Models.Carts;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;
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

        //Checks if user have existing cart by userId
        public async Task<ShoppingCart> ShoppingCartExistByUserIdAsync(string userId)
        {
            var cart = await repository
                .AllAsReadOnly<ShoppingCart>()
                .Include(sc => sc.ShoppingCartProducts)
                .ThenInclude(scp => scp.Product)
                .FirstOrDefaultAsync(sc => sc.UserId == userId);

            return cart;
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

        //Display the shopping cart as viewModel
        public async Task<CartViewModel> GetShoppingCartAsync(string userId)
        {
            var cart = await repository
                .AllAsReadOnly<ShoppingCart>()
                .Include(sc => sc.ShoppingCartProducts)
                .ThenInclude(scp => scp.Product)
                .FirstOrDefaultAsync(sc => sc.UserId == userId);

            var categoies = await productService.GetAllCategoriesAsync();

            var model = new CartViewModel()
            {
                Id = cart.Id,
                ProductsCounter = cart.ShoppingCartProducts.Sum(p => p.Quantity),
                TotalPrice = cart.TotalPrice,
                ShoppingCartProducts = cart.ShoppingCartProducts.Select(scp => new CartProductViewModel()
                {
                    ProductId = scp.ProductId,
                    Name = scp.Product.Name,
                    Quantity = scp.Quantity,
                    UnitPrice = scp.Price,
                    ImageUrl = scp.Product.ImageUrl,
                    Category = categoies.FirstOrDefault(c => c.Id == scp.Product.CategoryId).Name
                }).ToList()
            };
            return model;
        }

        //Mixed service, which calls other two methods - get OR create cart and returns viewModel
        public async Task<CartViewModel> GetOrCreateShoppingCartAsync(string userId)
        {
            var existingCart = await ShoppingCartExistByUserIdAsync(userId);

            if (existingCart != null)
            {
                var model = await GetShoppingCartAsync(userId);
                return model;
            }
            else
            {
                var newCart = await CreateShoppingCartAsync(userId);
                var model = await GetShoppingCartAsync(userId);
                return model;
            }
        }

        //Add a product to the shopping cart
        public async Task<bool> AddProductToCartAsync(string userId, int productId, int quantity)
        {
            var cart = await ShoppingCartExistByUserIdAsync(userId);

            if (cart == null)
            {
                return false;
            }

            var productInCart = cart.ShoppingCartProducts.FirstOrDefault(p => p.ProductId == productId);

            if (productInCart != null)
            {
                productInCart.Quantity += quantity;
            }
            else
            {
                var newProductInCart = new ShoppingCartProduct
                {
                    ProductId = productId,
                    Quantity = quantity,
                    ShoppingCartId = cart.Id,
                    Price = (decimal)await productService.GetProductPriceAsync(productId),
                };

                await repository.AddAsync(newProductInCart);
                await repository.SaveChangesAsync();
                
            };

            cart.TotalPrice += (decimal)(await productService.GetProductPriceAsync(productId)) * quantity;
            cart.ProductsCounter += quantity;

            await repository.SaveChangesAsync();
            return true;
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

            if (cart != null)
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
            var cart = await GetShoppingCartAsync(userId);

            return !cart.ShoppingCartProducts.Any();
        }

        public async Task<bool> SaveAsync()
        {
            await repository.SaveChangesAsync();
            return true;
        }
    }
}



