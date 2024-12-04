using FlowerStore.Components;
using FlowerStore.Core.ViewModels.CardDetails;
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
        /// <summary>
        /// This view model represents detailed information abount an order - with eventual CardDetails (card payment)
        /// </summary>
        
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

        [Required]
        [StringLength(FirstNameMaxLength,
            MinimumLength = FirstNameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(LastNameMaxLength,
            MinimumLength = LastNameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = InvalidFieldErrorMessage)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone(ErrorMessage = InvalidFieldErrorMessage)]
        public string PhoneNumber { get; set; } = string.Empty;

        public CardDetailsAddViewModel? CardDetails { get; set; }
        public IEnumerable<OrderStatusViewModel> OrderStatuses { get; set; } = new List<OrderStatusViewModel>();
        public IEnumerable<PaymentMethodViewModel> PaymentMethods { get; set; } = new List<PaymentMethodViewModel>();
        public IEnumerable<OrderProductViewModel> OrderProducts { get; set; } = new List<OrderProductViewModel>();
    }
}

