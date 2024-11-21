namespace FlowerStore.Core.ViewModels.Order
{
    /// <summary>
    /// ViewModel for paginated orders.
    /// </summary>
    public class OrdersPaginatedViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<OrderAllViewModel> Orders { get; set; } = new List<OrderAllViewModel>();
    }
}
