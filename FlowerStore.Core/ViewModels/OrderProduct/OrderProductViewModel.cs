namespace FlowerStore.Core.ViewModels.OrderProduct
{
    /// <summary>
    /// OrderProductViewModel represents view model that contains the data about products extracted from cart. It's reused.
    /// </summary>

    public class OrderProductViewModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Price * Quantity;
    }
}
