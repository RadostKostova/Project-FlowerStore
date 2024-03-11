namespace FlowerStore.Core.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool Availability { get; set; }
        public string FullDescription { get; set; } = string.Empty;
        public int FlowersCount { get; set; } 
    }
}
