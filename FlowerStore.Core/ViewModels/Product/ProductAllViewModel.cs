namespace FlowerStore.Core.ViewModels.Product
{
    /// <summary>
    /// This ViewModel will display Catalog with products with some of the details.
    /// </summary>
    
    public class ProductAllViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }   
        public string ImageUrl { get; set; } = string.Empty;

        public string Category { get; set; } = null!;
    }
}
