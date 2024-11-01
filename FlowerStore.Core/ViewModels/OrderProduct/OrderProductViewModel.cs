using System.ComponentModel.DataAnnotations;

namespace FlowerStore.Core.ViewModels.OrderProduct
{
    /// <summary>
    /// OrderProductViewModel represents view model that contains the data about products extracted from cart.
    /// </summary>
    
    public class OrderProductViewModel
    {   
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Price * Quantity;
    }
}
