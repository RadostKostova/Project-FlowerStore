using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerStore.Infrastructure.Data.Models.Categories
{
    public class ProductCategory
    {
        [Required]
        [Comment("Product identifier")]
        public int ProductId { get; set; }

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
    }
}
