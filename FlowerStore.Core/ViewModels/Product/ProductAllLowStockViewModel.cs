namespace FlowerStore.Core.ViewModels.Product
{
    /// <summary>
    /// This viewModel displays low-stock products.
    /// </summary>
    public class ProductAllLowStockViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int FlowersCount { get; set; }
    }
}
