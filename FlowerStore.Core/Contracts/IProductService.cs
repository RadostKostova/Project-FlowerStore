using FlowerStore.Core.ViewModels.Product;
using FlowerStore.Infrastructure.Data.Models;

namespace FlowerStore.Core.Contracts
{
    /// <summary>
    /// Interface for Product Service. Implement needed methods for further operations.
    /// </summary>
    
    public interface IProductService
    {
        Task<IEnumerable<ProductAllViewModel>> ShowAllProductsAsync();
        Task<Product> ProductByIdExistAsync(int productId);
        Task<int> GetProductCountAsync(int productId);
        Task<bool> GetAvailabilityAsync(int productId);
        Task<ProductDetailsViewModel> GetProductDetailsAsync(int productId);
        Task<IEnumerable<ProductAllViewModel>> SearchProductAsync(string input);
    }
}
