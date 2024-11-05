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

        //OrderProduct entity
        public const int OrderProductMinQuantity = 1;
        public const int OrderProductMaxQuantity = 15;
        public const double OrderProductUnitPriceMinLength = 1;
        public const double OrderProductUnitPriceMaxLength = 500;

        //Order entity
        public const double OrderTotalPriceMinLength = 1;
        public const double OrderTotalPriceMaxLength = 2000;
        public const int AddressMinLength = 10;
        public const int AddressMaxLength = 100;

        //Product entity
        public const int ProductNameMinLength = 5;
        public const int ProductNameMaxLength = 30;
        public const double ProductPriceMinLength = 1;
        public const double ProductPriceMaxLength = 500;
        public const int ProductDescriptionMinLength = 20;
        public const int ProductDescriptionMaxLength = 3000;
        public const int ProductCountMinLength = 0;
        public const int ProductCountMaxLength = 20;

        //OrderStatus entity
        public const int OrderStatusMinLength = 3;
        public const int OrderStatusMaxLength = 15;

        //ShoppingCart entity
        public const int ProductsInCartQuantityMinLength = 0;
        public const int ProductsInCartQuantityMaxLength = 15;

        //User entity
        public const int UserFirstNameMinLength = 1;
        public const int UserFirstNameMaxLength = 50;
        public const int UserLastNameMinLength = 1;
        public const int UserLastNameMaxLength = 50;
        public const int UserPhoneExactlyLength = 10;
    }
}
