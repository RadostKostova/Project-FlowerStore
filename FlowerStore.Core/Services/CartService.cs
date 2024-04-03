﻿using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Cart;
using FlowerStore.Core.ViewModels.CartProduct;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data.Models.Cart;
using FlowerStore.Infrastructure.Data.Models.Carts;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Core.Services
{
    /// <summary>
    /// Shopping Cart services implemented for more code reusability.
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

        //Check if user has a cart
        //public async Task<bool> ShoppingCartExistAsync(string userId)
        //{
        //    var cart = await repository
        //        .All<ShoppingCart>()
        //        .AnyAsync(sc => sc.UserId == userId);

        //    return cart;
        //}

        //Creates new shopping cart
        //public async Task<ShoppingCart> CreateShoppingCartAsync(string userId)
        //{
        //    var newCart = new ShoppingCart
        //    {
        //        UserId = userId,
        //        ProductsCounter = 0, 
        //        TotalPrice = 0,      
        //        ShoppingCartProducts = new List<ShoppingCartProduct>() 
        //    };

        //    await repository.AddAsync(newCart);
        //    await repository.SaveChangesAsync();

        //    return newCart;
        //}


        //Get or create a cart, depending on whether the user already has one
        public async Task<ShoppingCart> GetOrCreateShoppingCartAsync(string userId)
        {
            var existingCart = await repository
                .All<ShoppingCart>()
                .Include(sc => sc.ShoppingCartProducts)
                .FirstOrDefaultAsync(sc => sc.UserId == userId);

            if (existingCart != null)
            {
                return existingCart;
            }
            else
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
        }

        //Return the ViewModel for the shopping cart
        public async Task<CartViewModel> ViewShoppingCartAsync(string userId)
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
                    Id = scp.Id,
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

        //Add a product to the shopping cart
        public async Task<bool> AddProductToCartAsync(string userId, int productId, int quantity)
        {
            var cart = await GetOrCreateShoppingCartAsync(userId);

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

                cart.ShoppingCartProducts.Add(newProductInCart);
            };

            cart.TotalPrice += (decimal)(await productService.GetProductPriceAsync(productId)) * quantity;
            cart.ProductsCounter += quantity;

            await repository.SaveChangesAsync();
            return true;
        }

        //Remove product from shopping cart
        public async Task<bool> RemoveProductFromCartAsync(string userId, int productId)
        {
            var cart = await GetOrCreateShoppingCartAsync(userId);

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

            cart.ShoppingCartProducts.Remove(product);

            await repository.SaveChangesAsync();
            return true;
        }

        public async Task<CartProductViewModel> GetProductInCartByIdAsync(int cartId, int productId)
        {
            var product = await repository
                .AllAsReadOnly<ShoppingCartProduct>()
                .Include(scp => scp.Product)
                .Where(scp => scp.ShoppingCartId == cartId && scp.ProductId == productId)
                .Select(scp => new CartProductViewModel()
                {
                    Id = scp.Id,
                    ProductId = scp.ProductId,
                    Name = scp.Product.Name,
                    Quantity = scp.Quantity,
                    UnitPrice = scp.Price,
                    ImageUrl = scp.Product.ImageUrl
                })
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<bool> SaveAsync()
        {
            await repository.SaveChangesAsync();
            return true;
        }
    }
}



