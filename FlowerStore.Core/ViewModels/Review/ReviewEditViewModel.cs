using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;
using static FlowerStore.Infrastructure.Constants.ErrorConstants;

namespace FlowerStore.Core.ViewModels.Review
{
    /// <summary>
    /// ViewModel for editing review.
    /// </summary>
    public class ReviewEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(ReviewContentMaxLength,
            MinimumLength = ReviewContentMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = string.Empty;
    }
}
