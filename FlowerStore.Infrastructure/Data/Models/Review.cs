using FlowerStore.Infrastructure.Data.Models.Roles;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models
{
    /// <summary>
    /// This entity represents user review (only authenticated users will be able to post reviews)
    /// </summary>

    public class Review
    {
        [Key]
        [Comment("Review identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ReviewContentMaxLength)] 
        [Comment("Content of review")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [DisplayFormat(DataFormatString = DateFormatNeeded,
            ApplyFormatInEditMode = true)]
        [Comment("Creation date")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
    }
}
