using FlowerStore.Core.ViewModels.CartProduct;

namespace FlowerStore.Core.ViewModels.Cart
{
    /// <summary>
    /// This View Model represents the Shopping Cart.
    /// </summary>

    public class CartViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int ProductsCounter { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<CartProductViewModel> ShoppingCartProducts { get; set; } = new List<CartProductViewModel>();
    }
}
