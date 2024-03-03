using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;
using FlowerStore.Infrastructure.Data.Models.Enums;

namespace FlowerStore.Infrastructure.Data.Models
{
    /// <summary>
    /// The cart entity represents the temporary storage of flowers that a customer intends to purchase.
    /// </summary>

    public class ShoppingCart
    {
        [Key]
        [Comment("Cart identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Customer identifier")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;

        [Required]
        [Comment("Flower identifier")]
        public int FlowerId { get; set; }

        [ForeignKey(nameof(FlowerId))]
        public Flower Flower { get; set; } = null!;

        [Required]
        [MaxLength(ProductsQuantityMaxLength)]                 
        [Comment("Products quantity in cart")]
        public int ProductsQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        //[Range(typeof(decimal), DataMinLength, DataMaxLength, ConvertValueInInvariantCulture = true)]
        [Comment("Price of products in cart")]
        public decimal TotalPrice { get; set; }

        [Required]
        [EnumDataType(typeof(PaymentType))]
        [Comment("Chosen payment identifier")]
        public int PaymentMethodId { get; set; }

        [ForeignKey(nameof(PaymentMethod))]
        public PaymentMethod PaymentMethod { get; set; } = null!;
    }
}
