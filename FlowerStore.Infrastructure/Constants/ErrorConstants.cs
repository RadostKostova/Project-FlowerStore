namespace FlowerStore.Infrastructure.Constants
{
    /// <summary>
    /// Contains error messages for validations.
    /// </summary>
    public static class ErrorConstants
    {
        //Universal Error Messages
        public const string StringLengthErrorMessage = "The field {0} should be exactly between {2} and {1} characters long.";

        public const string DateFormatErrorMessage = "Date must be in dd/MM/yyyy HH:mm format.";

        //Card entity error messages
        public const string CardNumberErrorMessage = "The {0} field should be exactly {1} numbers.";
        public const string CardExpirationDateErrorMessage = "The {0} field should be in MM/yy format.";
        public const string CardCVVErrorMessage = "The {0} code should be exactly {1} numbers.";

        //Order entity error messages
        public const string CustomerMaxTotalPriceErrorMessage = "This is suspicious. You cannot place an order over BGN {1}, but you can still place a second one.";


    }
}
