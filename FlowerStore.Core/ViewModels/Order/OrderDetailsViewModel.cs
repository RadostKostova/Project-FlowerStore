using FlowerStore.Core.ViewModels.OrderProduct;

namespace FlowerStore.Core.ViewModels.Order
{
    public class OrderDetailsViewModel
    {
        public int OrderId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderDetails { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public string OrderStatus { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public IEnumerable<OrderProductViewModel> OrderProducts { get; set; } = new List<OrderProductViewModel>();
    }
}
