using FlowerStore.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FlowerStore.Infrastructure.Data.Models
{
    /// <summary>
    /// This entity represents the type of payment chosen for each order. Options: "Cash" or "Card"  
    /// </summary>
    
    public class PaymentMethod
    {
        [Key]
        [Comment("Chosen payment idenfitier")]
        public int Id { get; set; }

        [Required]
        [Comment("Option name")]
        public string Name { get; set; } = string.Empty;

        [EnumDataType(typeof(PaymentType))]
        public PaymentType PaymentType { get; set; }
    }
}
