﻿using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;
using static FlowerStore.Infrastructure.Constants.ErrorConstants;

namespace FlowerStore.Core.ViewModels.CardDetails
{
    public class CardDetailsAddViewModel
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [MaxLength(CardNumberExactlyLength)]
        [RegularExpression(CardNumberRegexFormat, 
            ErrorMessage = CardNumberErrorMessage)]
        public string CardNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(CardExpirationExactlyLength)]
        [RegularExpression(CardExpirationRegexDateFormat,
            ErrorMessage = CardExpirationDateErrorMessage)]
        public string ExpirationDate { get; set; } = string.Empty; //Format MM/yy

        [Required]
        [MaxLength(CardCVVExactlyLength)]
        [RegularExpression(CardCVVRegexFormat, 
            ErrorMessage = CardCVVErrorMessage)]
        public string CVV { get; set; } = string.Empty;

        [Required]
        [MaxLength(CardHolderMaxLength)]
        public string CardHolderName { get; set; } = string.Empty;
    }
}