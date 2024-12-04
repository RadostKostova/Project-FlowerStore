using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models.Roles
{
    /// <summary>
    /// Represents User entity and extends IdentityUser with additional fields, which won't be required upon registration.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(UserFirstNameMaxLength)]
        [Comment("First name")]
        public string? FirstName { get; set; } = string.Empty;

        [MaxLength(UserLastNameMaxLength)]
        [Comment("Last name")]
        public string? LastName { get; set; } = string.Empty;

        [Phone]
        [MaxLength(UserPhoneExactlyLength)]
        [Comment("Phone number")]
        public override string? PhoneNumber { get; set; } = string.Empty;

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
