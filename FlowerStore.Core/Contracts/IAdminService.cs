using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Core.ViewModels.OrderStatus;
using FlowerStore.Core.ViewModels.Product;
using FlowerStore.Core.ViewModels.User;
using FlowerStore.Infrastructure.Data.Models;

namespace FlowerStore.Core.Contracts
{
    /// <summary>
    /// Interface for admin services.
    /// </summary>

    public interface IAdminService
    {
        //---------------------------------------------------------ORDER
        Task<IEnumerable<OrderAllViewModel>> GetAllOrdersAsync();
        Task<OrderDetailsViewModel> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<OrderStatusViewModel>> GetAllOrderStatusesAsync();
        Task<OrderEditStatusViewModel> GetOrderForStatusEditing(int orderId);
        Task<bool> EditStatusAsync(int orderId, int newStatusId);

        //--------------------------------------------------------USER
        Task<IEnumerable<UserAllViewModel>> GetAllUsersAsync();

        //--------------------------------------------------------PRODUCT
        Task<int> AddProductAsync(ProductAddViewModel model);
        Task<ProductEditViewModel> GetEditProductAsync(int productId);
        Task<ProductEditViewModel> PostEditProductAsync(ProductEditViewModel model);
        Task<ProductDeleteViewModel> DeleteProductAsync(int productId);
        Task<int> ConfirmDeleteAsync(int productId);
        Task<IEnumerable<Product>> GetLowStockProductsAsync(int threshold = 3);
    }
}
