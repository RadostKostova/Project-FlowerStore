using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models
{
    /// <summary>
    /// Represents information about each flower in the online store. 
    /// </summary>
    public class Flower
    {
        [Key]
        [Comment("Flower identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(FlowerNameMaxLength)]
        [Comment("Flower name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        //[Range(typeof(decimal), DataMinLength, DataMaxLength, ConvertValueInInvariantCulture = true)]
        [Comment("Flower price")]
        public decimal Price { get; set; }

        [Required]                            //will be modified (Azure?)
        [Comment("Flower image")]
        public string Image { get; set; } = string.Empty;

        [Required]
        [Comment("Indicator for in stock/out of stock")]
        public bool Availability { get; set; }

        [Required]
        [MaxLength(FlowerDescriptionMaxLength)]
        [Comment("Flower description")]
        public string FullDescription { get; set; } = string.Empty;

        [Comment("Order identifier")]
        public int? OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [MaxLength(FlowerCountMaxLength)]
        public int? FlowersCount { get; set; } = null!;
    }
}
