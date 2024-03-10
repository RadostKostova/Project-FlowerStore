using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerStore.Infrastructure.Data.Models.Orders.Order
{
    /// <summary>
    /// This entity represent a information about every single individual product in a order (Order Line).
    /// </summary>

    public class ProductOrder
    {
        [Key]
        [Comment("Order line identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Order identifier")]
        public int OrderId { get; set; }

        [Required]
        [Comment("Product identifier")]
        public int ProductId { get; set; }

        [Required]
        [Comment("Quantity of products in order")]
        public int Quantity { get; set; }

        [Required]
        [Comment("Unit's price of product")]
        public decimal UnitPrice { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
