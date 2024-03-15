namespace FlowerStore.Infrastructure.Constants
{
    /// <summary>
    /// Contains error messages for validations.
    /// </summary>
    public static class ErrorConstants
    {
        //Universal Error Messages
        public const string StringLengthErrorMessage = "The field {0} should be between {2} and {1} characters long.";
        public const string NumberRangeErrorMessage = "The field {0} should be between {2} and {1}.";

        public const string DateFormatErrorMessage = "Date must be in dd/MM/yyyy HH:mm format.";

        public const string ExactNumberErrorMessage = "The {0} field should be exactly {1} numbers.";

        public const string ImageUrlErrorMessage = "The {0} should be valid URL. Only images with extension .jpg and .png are allowed.";

        //Card entity error messages
        public const string CardExpirationDateErrorMessage = "The {0} field should be in MM/yy format.";
        public const string CardCVVErrorMessage = "The {0} code should be exactly {1} numbers.";
    }
}
