using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models
{
    /// <summary>
    /// Categories help organize flowers into logical groups for easier navigation and search.
    /// </summary>

    public class Category
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("Name of category")]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
