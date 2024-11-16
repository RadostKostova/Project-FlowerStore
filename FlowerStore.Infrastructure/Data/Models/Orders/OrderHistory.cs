using FlowerStore.Infrastructure.Data.Models.Payment;
using FlowerStore.Infrastructure.Data.Models.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models.Orders.Order
{
    /// <summary>
    /// Pernament history of orders that the User has made. 
    /// </summary>

    public class OrderHistory
    {
        [Key]
        [Comment("Order history identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Order identifier")]
        public int OrderId { get; set; }

        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [DisplayFormat(DataFormatString = DateFormatNeeded, ApplyFormatInEditMode = true)]
        [Comment("Order date")]
        public DateTime OrderDate { get; set; }

        [Comment("Additional details of the order")]
        public string? OrderDetails { get; set; }

        [Required]
        [MaxLength(AddressMaxLength)]
        [Comment("Shipping address")]
        public string ShippingAddress { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Total order price")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Comment("Payment method identifier")]
        public int PaymentMethodId { get; set; }

        [Required]
        [Comment("Order status identifier")]
        public int OrderStatusId { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        [Comment("First name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(LastNameMaxLength)]
        [Comment("Last name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Comment("Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        [Comment("Phone")]
        public string Phone { get; set; } = string.Empty;

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [ForeignKey(nameof(PaymentMethodId))]
        public PaymentMethod PaymentMethod { get; set; } = null!;

        [ForeignKey(nameof(OrderStatusId))]
        public OrderStatus OrderStatus { get; set; } = null!;

        public virtual ICollection<OrderProductHistory> OrderProducts { get; set; } = new List<OrderProductHistory>();
    }
}
