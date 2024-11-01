using System.ComponentModel.DataAnnotations;

namespace FlowerStore.Core.ViewModels.CartProduct
{
    /// <summary>
    /// This view model represents each product in the Shopping Cart.
    /// </summary>
    
    public class CartProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice; //auto sum?
        public string ImageUrl { get; set; } = string.Empty; 
        public string Category { get; set; } = string.Empty;
    }
}
