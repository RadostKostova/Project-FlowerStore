using FlowerStore.Core.ViewModels.Category;
using FlowerStore.Core.ViewModels.Product;
using FlowerStore.Infrastructure.Data.Models;

namespace FlowerStore.Core.Contracts
{
    /// <summary>
    /// Interface for Product Service.
    /// </summary>

    public interface IProductService
    {
        Task<IEnumerable<ProductAllViewModel>> ShowAllProductsAsync();
        Task<Product> ProductByIdExistAsync(int productId);
        Task<ProductDetailsViewModel> GetProductDetailsAsync(int productId);
        Task<decimal?> GetProductPriceAsync(int productId);
        Task<IEnumerable<ProductAllViewModel>> SearchProductAsync(string searchString);
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
        Task UpdateProductStockAsync(int productId, int quantity);
        Task<ProductsPaginatedViewModel> GetPaginatedProductsAsync(int page, int pageSize);
    }
}
