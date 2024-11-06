using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerStore.Infrastructure.Data.Models.Orders
{
    public class OrderProductHistory
    {
        [Key]
        [Comment("Order product identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Order history identifier")]
        public int OrderHistoryId { get; set; }

        [Required]
        [Comment("Product identifier")]
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Price per unit")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Quantity of product")]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(100)]
        [Comment("Product name at the time of order")]
        public string ProductName { get; set; } = string.Empty;

        [ForeignKey(nameof(OrderHistoryId))]
        public OrderHistory OrderHistory { get; set; } = null!;
    }
}
