using FlowerStore.Components;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models.Orders.Order
{
    public class OrderProduct
    {
        [Required]
        [Comment("Order identifier")]
        public int OrderId { get; set; }

        [Required]
        [Comment("Product identifier")]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(ProductCountMaxLength)]
        [Comment("Quantity of product")]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DecimalRange(ProductPriceMinLength, ProductPriceMaxLength)]
        [Comment("Price of product")]
        public decimal Price { get; set; }       

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
