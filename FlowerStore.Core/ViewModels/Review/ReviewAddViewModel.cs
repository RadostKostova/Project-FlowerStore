using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;
using static FlowerStore.Infrastructure.Constants.ErrorConstants;

namespace FlowerStore.Core.ViewModels.Review
{
    /// <summary>
    /// ViewModel for adding new review in the database. 
    /// The CreatedAt prop won't be [Required] here because it will be populated inside the POST action with DateTime.Now;
    /// It has [Required] attribute in the Review.cs entity.
    /// </summary>
    public class ReviewAddViewModel
    {
        [Required]
        [StringLength(ReviewContentMaxLength, 
            MinimumLength = ReviewContentMinLength, 
            ErrorMessage = StringLengthErrorMessage)]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = string.Empty;
    }
}
