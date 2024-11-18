namespace FlowerStore.Core.ViewModels.Order
{
    public class OrderAllViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string OrderDate { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string? OrderDetails { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public string OrderStatus { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
