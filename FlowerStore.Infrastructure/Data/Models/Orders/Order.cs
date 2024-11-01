using FlowerStore.Components;
using FlowerStore.Infrastructure.Data.Models.Cart;
using FlowerStore.Infrastructure.Data.Models.Payment;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models.Orders.Order
{
    /// <summary>
    /// An order represents a user's purchase of one or more products and all the data needed for a single purcase.
    /// </summary>
    public class Order
    {
        [Key]
        [Comment("Order identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [DisplayFormat(DataFormatString = DateFormatNeeded,
            ApplyFormatInEditMode = true)]
        [Comment("Order date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DecimalRange(OrderTotalPriceMinLength, OrderTotalPriceMaxLength)]
        [Comment("Payment amount")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Comment("Chosen payment identifier")]
        public int PaymentMethodId { get; set; }

        [Comment("More details of the order")]
        public string? OrderDetails { get; set; }

        [Required]
        [MaxLength(AddressMaxLength)]
        [Comment("Shipping address")]
        public string ShippingAddress { get; set; } = string.Empty;

        [Required]
        [Comment("Order status identifier")]
        public int OrderStatusId { get; set; }

        [Required]
        [Comment("Shopping Cart identifier")]
        public int ShoppingCartId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [ForeignKey(nameof(PaymentMethodId))]
        public PaymentMethod PaymentMethod { get; set; } = null!;

        [ForeignKey(nameof(OrderStatusId))]
        public OrderStatus OrderStatus { get; set; } = null!;

        [ForeignKey(nameof(ShoppingCartId))]
        public ShoppingCart ShoppingCart { get; set; } = null!;

        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}