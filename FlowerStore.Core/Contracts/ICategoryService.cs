using FlowerStore.Core.ViewModels.Category;

namespace FlowerStore.Core.Contracts
{
    /// <summary>
    /// Interface for Category Service.
    /// </summary>

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync(int productId);
    }
}
