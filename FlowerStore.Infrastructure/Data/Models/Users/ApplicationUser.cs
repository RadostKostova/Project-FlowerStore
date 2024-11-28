using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models.Roles
{
    /// <summary>
    /// Represents User entity and extends IdentityUser with additional fields.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        [Comment("First name")]
        public string? FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        [Comment("Last name")]
        public string? LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(UserPhoneExactlyLength)]
        [Comment("Phone number")]
        public string? Phone { get; set; } = string.Empty;

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
