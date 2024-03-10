namespace FlowerStore.Infrastructure.Constants
{
    /// <summary>
    /// Contains data constants for the entities in DB.
    /// </summary>
    public static class DataConstants
    {
        //Date format mostly used
        public const string DateFormatNeeded = "dd/MM/yyyy HH:mm";

        //Card entity
        public const string CardExpirationDateFormat = "{0:MM/yy}";
        public const int CardNumberExactlyLength = 16;       
        public const int CardCVVExactlyLength = 3;
        public const int CardHolderMinLength = 5;
        public const int CardHolderMaxLength = 30;

        // Category entity
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 40;

        //Order entity
        public const int ProductOrderMaxQuantity = 20;
        public const int OrderDetailsMaxLength = 100;

        //Product entity
        public const int ProductNameMinLength = 5;
        public const int ProductNameMaxLength = 30;

        public const decimal ProductPriceMinLength = 1m;
        public const decimal ProductPriceMaxLength = 200m;

        public const int ProductDescriptionMinLength = 20;
        public const int ProductDescriptionMaxLength = 1000;

        public const int ProductCountMaxLength = 10;

        //OrderStatus entity
        public const int OrderStatusMinLength = 3;
        public const int OrderStatusMaxLength = 15;

        //ShoppingCart entity
        public const int ProductsInCartQuantityMaxLength = 15;
       
    }
}
