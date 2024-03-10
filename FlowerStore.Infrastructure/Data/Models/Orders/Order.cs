using FlowerStore.Infrastructure.Data.Models.Payment;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models.Orders.Order
{
    /// <summary>
    /// An order represents a user's purchase of one or more flowers.
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
        [Comment("Payment amount")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Comment("Chosen payment identifier")]
        public int PaymentMethodId { get; set; }

        [Required]
        [MaxLength(OrderDetailsMaxLength)]
        [Comment("More details of the order")]
        public string OrderDetails { get; set; } = string.Empty;

        [Required]
        [EnumDataType(typeof(OrderStatus))]
        [Comment("Status of the order")]
        public OrderStatus? OrderStatus { get; set; }


        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [ForeignKey(nameof(PaymentMethodId))]
        public PaymentMethod? PaymentMethod { get; set; }

        public virtual ICollection<ProductOrder> OrdersProducts { get; set; } = new List<ProductOrder>();
    }
}