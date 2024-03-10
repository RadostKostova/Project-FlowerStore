using FlowerStore.Infrastructure.Data.Models.Cart;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerStore.Infrastructure.Data.Models.Carts
{
    /// <summary>
    /// UserShoppingCart represents a mapping table between Product and Shopping Cart entities.
    /// </summary>

    public class ProductShoppingCart
    {
        [Required]
        [Comment("Product identifier")]
        public int ProductId { get; set; }

        [Required]
        [Comment("Cart identifier")]
        public int ShoppingCartId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [ForeignKey(nameof(ShoppingCartId))]
        public ShoppingCart? ShoppingCart { get; set; }
    }
}
