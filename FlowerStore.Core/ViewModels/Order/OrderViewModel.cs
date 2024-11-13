using FlowerStore.Components;
using FlowerStore.Core.ViewModels.OrderProduct;
using FlowerStore.Core.ViewModels.OrderStatus;
using FlowerStore.Core.ViewModels.PaymentMethod;
using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;
using static FlowerStore.Infrastructure.Constants.ErrorConstants;

namespace FlowerStore.Core.ViewModels.Order
{
    public class OrderViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [DisplayFormat(DataFormatString = DateFormatNeeded,
            ApplyFormatInEditMode = true)]
        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [DecimalRange(OrderTotalPriceMinLength,  
            OrderTotalPriceMaxLength,
            ErrorMessage = NumberRangeErrorMessage)]
        [Display(Name = "Total price")]
        public decimal TotalPrice { get; set; }

        [Required]
        public int PaymentMethodId { get; set; }

        [Display(Name = "Order details")]
        public string? OrderDetails { get; set; }

        [Required]
        [StringLength(AddressMaxLength, 
            MinimumLength = AddressMinLength, 
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; } = string.Empty;

        [Required]
        public int OrderStatusId { get; set; }

        [Required]
        public int ShoppingCartId { get; set; }

        public IEnumerable<OrderStatusViewModel> OrderStatuses { get; set; } = new List<OrderStatusViewModel>();
        public IEnumerable<PaymentMethodViewModel> PaymentMethods { get; set; } = new List<PaymentMethodViewModel>();
        public IEnumerable<OrderProductViewModel> OrderProducts { get; set; } = new List<OrderProductViewModel>();
    }
}
