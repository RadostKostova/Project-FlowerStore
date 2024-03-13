namespace FlowerStore.Infrastructure.Constants
{
    /// <summary>
    /// Contains data constants for the entities. Price constants will be written as type double, because they will be handled
    /// later with custom attribute, which will parse the prices to decimal.
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

        //ProductOrder entity
        public const int ProductOrderMinQuantity = 1;
        public const int ProductOrderMaxQuantity = 20;
        public const double ProductOrderUnitPriceMinLength = 1;
        public const double ProductOrderUnitPriceMaxLength = 500;

        //Order entity
        public const int OrderDetailsMinLength = 0;
        public const int OrderDetailsMaxLength = 150;
        public const double OrderTotalPriceMinLength = 1;
        public const double OrderTotalPriceMaxLength = 2000;

        //Product entity
        public const int ProductNameMinLength = 5;
        public const int ProductNameMaxLength = 30;
        public const double ProductPriceMinLength = 1;
        public const double ProductPriceMaxLength = 500;
        public const int ProductDescriptionMinLength = 20;
        public const int ProductDescriptionMaxLength = 1000;
        public const int ProductCountMinLength = 0;
        public const int ProductCountMaxLength = 10;

        //OrderStatus entity
        public const int OrderStatusMinLength = 3;
        public const int OrderStatusMaxLength = 15;

        //ShoppingCart entity
        public const int ProductsInCartQuantityMinLength = 0;
        public const int ProductsInCartQuantityMaxLength = 15;

    }
}
