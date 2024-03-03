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

        //Customer entity
        public const int CustomersFirstNameMinLength = 2;
        public const int CustomersFirstNameMaxLength = 20;

        public const int CustomersLastNameMinLength = 4;
        public const int CustomersLastNameMaxLength = 20;

        public const int CustomersAddressMinLength = 10;
        public const int CustomersAddressMaxLength = 50;

        public const int CustomersSpecificsAddressMaxLength = 100;

        //Order entity
        public const decimal OrderMaxTotalPrice = 2000m;
        public const int ShippingDetailsMaxLength = 100;

        //Flower entity
        public const int FlowerNameMinLength = 5;
        public const int FlowerNameMaxLength = 30;

        public const decimal FlowerPriceMinLength = 1m;
        public const decimal FlowerPriceMaxLength = 200m;

        public const int FlowerDescriptionMinLength = 20;
        public const int FlowerDescriptionMaxLength = 1000;

        public const int FlowerCountMaxLength = 10;

        //ShoppingCart entity
        public const int ProductsQuantityMaxLength = 1000;
    }
}
