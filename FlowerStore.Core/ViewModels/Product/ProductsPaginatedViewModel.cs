namespace FlowerStore.Core.ViewModels.Product
{
    /// <summary>
    /// ViewModel for product pagination and sorting
    /// </summary>
    public class ProductsPaginatedViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<ProductAllViewModel> Products { get; set; } = new List<ProductAllViewModel>();
        public string SortOrder { get; set; } = string.Empty;
    }
}
