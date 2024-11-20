using FlowerStore.Components;
using FlowerStore.Infrastructure.Data.Models.Carts;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents information about each flower in the online store. Availability by default is false.
    /// </summary>

    public class Product
    {
        [Key]
        [Comment("Product identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        [Comment("Product name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DecimalRange(ProductPriceMinLength, ProductPriceMaxLength)]
        [Comment("Price of product")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [Required]                      
        [Comment("Product image")]          //will be modified (Azure?)
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Indicator for in stock/out of stock")]
        public bool Availability { get; set; } = false;

        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        [Comment("Product description")]
        public string FullDescription { get; set; } = string.Empty;

        [Required]
        [DisplayFormat(DataFormatString = DateFormatNeeded, ApplyFormatInEditMode = true)]
        [Comment("Product add date")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Comment("Counter of product in stock")]
        [MaxLength(ProductCountMaxLength)]
        public int FlowersCount { get; set; }

        [Required]
        [Comment("Product category")]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
    }
}
