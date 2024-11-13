using FlowerStore.Core.ViewModels.Cart;
using FlowerStore.Core.ViewModels.CartProduct;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data.Models.Cart;

namespace FlowerStore.Core.Contracts
{
    /// <summary>
    /// Interface for CartService
    /// </summary>

    public interface ICartService
    {
        Task<ShoppingCart> ShoppingCartExistByUserIdAsync(string userId);
        Task<ShoppingCart> CreateShoppingCartAsync(string userId);
        Task<CartViewModel> GetOrCreateShoppingCartAsync(string userId);
        Task<CartViewModel> GetShoppingCartAsync(string userId);
        Task<bool> AddProductToCartAsync(string userId, int productId, int quantity);
        Task<bool> RemoveProductFromCartAsync(string userId, int productId);
        Task<CartProductViewModel> GetProductInCartByIdAsync(int cartId, int productId);
        Task ClearCartAsync(string userId);
        Task<bool> IsShoppingCartEmpty(string userId);
        Task<bool> SaveAsync();
    }
}
