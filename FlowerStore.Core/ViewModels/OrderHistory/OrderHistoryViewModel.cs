using FlowerStore.Core.ViewModels.OrderProduct;
using System.ComponentModel.DataAnnotations;

namespace FlowerStore.Core.ViewModels.OrderHistory
{
    public class OrderHistoryViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string OrderStatus { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public List<OrderProductViewModel> OrderProducts { get; internal set; } = new List<OrderProductViewModel>();
    }
}

