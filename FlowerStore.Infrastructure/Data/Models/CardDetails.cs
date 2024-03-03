using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models
{
    /// <summary>
    /// This entity represents the details of customer's card. When the customer is placing an order and selects "Pay with Card", a 
    /// card form should appear and should be filled. This data should be sent to DB.
    /// </summary>
    
    public class CardDetails
    {       
        [Required]
        [Comment("Card identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CardNumberExactlyLength)]
        [Comment("Card number")]
        public string CardNumber { get; set; } = string.Empty;

        [Required]
        [DisplayFormat(DataFormatString = CardExpirationDateFormat, 
            ApplyFormatInEditMode = true)]
        [Comment("Card's expiration date")]
        public DateTime ExpirationDate { get; set; } //Format MM/yy

        [Required]
        [MaxLength(CardCVVExactlyLength)]
        [Comment("Code of Card Verification Value")]
        public string CVV { get; set; } = string.Empty;

        [Required]
        [MaxLength(CardHolderMaxLength)]
        [Comment("First and last name of holder")]
        public string CardHolderName { get; set; } = string.Empty;
    }
}
