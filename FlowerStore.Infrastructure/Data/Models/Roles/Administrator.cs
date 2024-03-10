using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Infrastructure.Data.Models.Roles
{
    /// <summary>
    /// Represents the Administrator.
    /// </summary>

    public class Administrator
    {
        [Key]
        [Comment("Administrator's Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("User's Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("User")]
        public IdentityUser User { get; set; } = null!;
    }
}
