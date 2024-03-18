﻿using FlowerStore.Infrastructure.Data.Models.Carts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models.Cart
{
    /// <summary>
    /// The cart entity represents the temporary storage of products (flowers) that a user intends to purchase.
    /// </summary>

    public class ShoppingCart
    {
        [Key]
        [Comment("Cart identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductsInCartQuantityMaxLength)]
        [Comment("Count of products in cart")]
        public int ProductsCounter { get; set; } 

        [Required]
        [Comment("User's Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;    

        public virtual ICollection<ShoppingCartProduct> ShoppingCartProducts { get; set; } = new List<ShoppingCartProduct>();
    }
}
