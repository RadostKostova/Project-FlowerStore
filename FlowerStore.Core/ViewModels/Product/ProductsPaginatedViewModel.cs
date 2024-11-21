namespace FlowerStore.Core.ViewModels.Product
{
    /// <summary>
    /// ViewModel for product pagination
    /// </summary>
    public class ProductsPaginatedViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<ProductAllViewModel> Products { get; set; } = new List<ProductAllViewModel>();
    }
}
