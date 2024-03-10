using FlowerStore.Infrastructure.Data.Models.Carts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerStore.Infrastructure.Data.Models.Cart
{
    /// <summary>
    /// The cart entity represents the temporary storage of flowers that a user intends to purchase.
    /// </summary>

    public class ShoppingCart
    {
        [Key]
        [Comment("Cart identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Product quantity in cart")]
        public int Quantity { get; set; }

        [Required]
        [Comment("User's Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;    

        public virtual ICollection<ProductShoppingCart> ProductsShoppingCart { get; set; } = new List<ProductShoppingCart>();
    }
}
