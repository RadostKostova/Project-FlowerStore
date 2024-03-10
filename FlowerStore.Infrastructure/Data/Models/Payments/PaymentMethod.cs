using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FlowerStore.Infrastructure.Data.Models.Payment
{
    /// <summary>
    /// This entity represents the type of payment chosen for each order.
    /// </summary>

    public class PaymentMethod
    {
        [Key]
        [Comment("Chosen payment idenfitier")]
        public int Id { get; set; }

        [Required]
        [Comment("Payment option name")]
        public string Name { get; set; } = string.Empty;
    }
}
