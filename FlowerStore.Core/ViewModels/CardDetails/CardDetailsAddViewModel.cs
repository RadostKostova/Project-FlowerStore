using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;
using static FlowerStore.Infrastructure.Constants.ErrorConstants;

namespace FlowerStore.Core.ViewModels.CardDetails
{
    public class CardDetailsAddViewModel
    {
        /// <summary>
        /// Represents card payment details
        /// </summary>
        
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [MaxLength(CardNumberExactlyLength)]
        [RegularExpression(CardNumberRegexFormat, 
            ErrorMessage = CardNumberErrorMessage)]
        [Display(Name = "Card number")]
        public string CardNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(CardExpirationExactlyLength)]
        [RegularExpression(CardExpirationRegexDateFormat,
            ErrorMessage = CardExpirationDateErrorMessage)]
        [Display(Name = "Expiration date")]
        public string ExpirationDate { get; set; } = string.Empty; //Format MM/yy

        [Required]
        [MaxLength(CardCVVExactlyLength)]
        [RegularExpression(CardCVVRegexFormat, 
            ErrorMessage = CardCVVErrorMessage)]
        public string CVV { get; set; } = string.Empty;

        [Required]
        [MaxLength(CardHolderMaxLength)]
        [Display(Name = "Cardholder name")]
        public string CardHolderName { get; set; } = string.Empty;
    }
}
