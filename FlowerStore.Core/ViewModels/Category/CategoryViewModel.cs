using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;
using static FlowerStore.Infrastructure.Constants.ErrorConstants;

namespace FlowerStore.Core.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryNameMaxLength,
           MinimumLength = CategoryNameMinLength,
           ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;
    }
}
