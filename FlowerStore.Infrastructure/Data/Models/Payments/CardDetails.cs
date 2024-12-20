﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models.Payment
{
    /// <summary>
    /// This entity represents the details of user's card. When the user is placing an order and selects "Pay with Card", a 
    /// card form should appear and should be filled. This data should be sent to DB.
    /// </summary>

    public class CardDetails
    {
        [Key]
        [Comment("Card identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [MaxLength(CardNumberExactlyLength)]
        [RegularExpression(CardNumberRegexFormat)]
        [Comment("Card number")]
        public string CardNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(CardExpirationExactlyLength)]
        [RegularExpression(CardExpirationRegexDateFormat)] //Format MM/yy
        [Comment("Card's expiration date")]
        public string ExpirationDate { get; set; } = string.Empty;

        [Required]
        [MaxLength(CardCVVExactlyLength)]
        [RegularExpression(CardCVVRegexFormat)]
        [Comment("Code of Card Verification Value")]
        public string CVV { get; set; } = string.Empty;

        [Required]
        [MaxLength(CardHolderMaxLength)]
        [Comment("First and last name of holder")]
        public string CardHolderName { get; set; } = string.Empty;
    }
}
