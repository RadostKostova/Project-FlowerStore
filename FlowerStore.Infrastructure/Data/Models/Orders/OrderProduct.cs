using FlowerStore.Components;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models.Orders.Order
{
    /// <summary>
    /// This entity represent a information about every single individual product in a order (Order Line).
    /// </summary>

    public class OrderProduct
    {
        [Key]
        [Comment("Order line identifier")]
        public int Id { get; set; }      

        [Required]
        [Comment("Product identifier")]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(OrderProductMaxQuantity)]
        [Comment("Unit's quantity of product")]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DecimalRange(OrderProductUnitPriceMinLength, OrderProductUnitPriceMaxLength)]
        [Comment("Unit's price of product")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Comment("Order identifier")]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
