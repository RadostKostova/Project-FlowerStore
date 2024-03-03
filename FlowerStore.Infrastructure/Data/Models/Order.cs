using FlowerStore.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models
{
    /// <summary>
    /// An order represents a customer's purchase of one or more flowers.
    /// </summary>

    public class Order
    {
        [Key]
        [Comment("Order identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Customer identifier")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;

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
        [EnumDataType(typeof(PaymentType))]
        [Comment("Chosen payment identifier")]
        public int PaymentMethodId { get; set; }

        [ForeignKey(nameof(PaymentMethod))]
        public PaymentMethod PaymentMethod { get; set; } = null!;

        [Required]
        [MaxLength(ShippingDetailsMaxLength)]
        [Comment("Order details")]
        public string ShippingDetails { get; set; } = string.Empty;

        [Required]
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus OrderStatus { get; set; }   //pending, shipped, delivered
    }
}