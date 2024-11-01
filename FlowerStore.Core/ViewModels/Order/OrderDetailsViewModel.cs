using FlowerStore.Core.ViewModels.OrderProduct;
using FlowerStore.Core.ViewModels.OrderStatus;
using FlowerStore.Core.ViewModels.PaymentMethod;
using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Core.ViewModels.Order
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = DateFormatNeeded,
            ApplyFormatInEditMode = true)]
        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Total price")]
        public decimal TotalPrice { get; set; }
        public int PaymentMethodId { get; set; }

        [Display(Name = "Order details")]
        public string OrderDetails { get; set; } = "";

        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; } = string.Empty;
        public int OrderStatusId { get; set; }
        public int ShoppingCartId { get; set; }

        public IEnumerable<OrderStatusViewModel> OrderStatuses { get; set; } = new List<OrderStatusViewModel>();
        public IEnumerable<PaymentMethodViewModel> PaymentMethods { get; set; } = new List<PaymentMethodViewModel>();
        public IEnumerable<OrderProductViewModel> OrderProducts { get; set; } = new List<OrderProductViewModel>();
    }
}
