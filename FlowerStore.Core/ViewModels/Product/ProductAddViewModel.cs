using FlowerStore.Components;
using FlowerStore.Core.ViewModels.Category;
using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;
using static FlowerStore.Infrastructure.Constants.ErrorConstants;

namespace FlowerStore.Core.ViewModels.Product
{
    /// <summary>
    /// This ViewModel represents Product entity, that will be added to database via form. Only the Admin should be able to access this.
    /// </summary>
    public class ProductAddViewModel
    {
        [Required]
        [StringLength(ProductNameMaxLength,
            MinimumLength = ProductNameMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; } = string.Empty;


        [Required]
        [DecimalRange(ProductPriceMinLength,
            ProductPriceMaxLength,
            ErrorMessage = NumberRangeErrorMessage)]
        public decimal Price { get; set; }


        [Required]
        [Display(Name = "Image url")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [StringLength(ProductDescriptionMaxLength,
            MinimumLength = ProductDescriptionMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string FullDescription { get; set; } = string.Empty;


        [Required]
        [Range(ProductCountMinLength,
            ProductCountMaxLength,
            ErrorMessage = NumberRangeErrorMessage)]
        public int FlowersCount { get; set; }


        [Required]
        public bool Availability { get; set; } = false;


        [Required]
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
