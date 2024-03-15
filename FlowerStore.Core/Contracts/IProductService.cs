using FlowerStore.Core.ViewModels.Category;
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
        Task<int> AddProductAsync(ProductAddViewModel model);
        Task<ProductEditViewModel> GetEditProductAsync(int productId);
        Task<ProductEditViewModel> PostEditProductAsync(ProductEditViewModel model);
        Task<ProductDetailsViewModel> GetProductDetailsAsync(int productId);
        Task<IEnumerable<ProductAllViewModel>> SearchProductAsync(string searchString);
        Task<Product> ProductByIdExistAsync(int productId);
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
    }
}
