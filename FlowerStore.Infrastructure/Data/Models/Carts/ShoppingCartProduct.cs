using FlowerStore.Components;
using FlowerStore.Infrastructure.Data.Models.Cart;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models.Carts
{
    /// <summary>
    /// ShoppingCartProduct represents temporary stored products before User places an Order. 
    /// </summary>

    public class ShoppingCartProduct
    {
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

        [Required]
        [Comment("Cart identifier")]
        public int ShoppingCartId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [ForeignKey(nameof(ShoppingCartId))]
        public ShoppingCart ShoppingCart { get; set; } = null!;
    }
}
