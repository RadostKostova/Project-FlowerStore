using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models
{
    /// <summary>
    /// This entity represents the individuals who visit your online store, browse flowers, and make purchases
    /// </summary>
    public class Customer : IdentityUser
    {
        [Required]
        [MaxLength(CustomersFirstNameMaxLength)]
        [Comment("Customer's first name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(CustomersLastNameMaxLength)]
        [Comment("Customer's last name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(CustomersAddressMaxLength)]
        [Comment("Customer's full address")]
        public string FullAddress { get; set; } = string.Empty;

        [MaxLength(CustomersSpecificsAddressMaxLength)]
        [Comment("Specifics for the customer's address")]
        public string SpecificsForAddress { get; set; } = string.Empty;

        public virtual ICollection<Order> OrderHistory { get; set; } = new List<Order>();
    }
}
