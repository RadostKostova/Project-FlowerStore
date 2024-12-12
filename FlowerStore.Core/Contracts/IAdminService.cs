using FlowerStore.Core.ViewModels.Admin;
using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Core.ViewModels.OrderStatus;
using FlowerStore.Core.ViewModels.Product;
using FlowerStore.Infrastructure.Data.Models.Roles;

namespace FlowerStore.Core.Contracts
{
    /// <summary>
    /// Interface for admin services. Manageing Orders, Users and and Products
    /// </summary>

    public interface IAdminService
    {
        //---------------------------------------------------------ORDER
        Task<OrdersPaginatedViewModel> GetPaginatedOrdersAsync(int page, int pageSize);
        Task<IEnumerable<OrderAllViewModel>> GetAllOrdersAsync();
        Task<OrderDetailsViewModel> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<OrderStatusViewModel>> GetAllOrderStatusesAsync();
        Task<OrderEditStatusViewModel> GetOrderForStatusEditingAsync(int orderId);
        Task<bool> EditStatusAsync(int orderId, int newStatusId);

        //--------------------------------------------------------USER
        Task<IEnumerable<UserAllViewModel>> GetAllUsersAsync();
        Task<UserDetailsViewModel> GetUserDetailsAsync(string userId);
        Task<ApplicationUser> GetUserByIdAsync(string userId);

        //--------------------------------------------------------PRODUCT
        Task<int> AddProductAsync(ProductAddViewModel model);
        Task<ProductEditViewModel> GetEditProductAsync(int productId);
        Task<ProductEditViewModel> PostEditProductAsync(ProductEditViewModel model);
        Task<ProductDeleteViewModel> DeleteProductAsync(int productId);
        Task<int> ConfirmDeleteAsync(int productId);
        Task<IEnumerable<ProductAllLowStockViewModel>> GetLowStockProductsAsync(int threshold = 3);
    }
}
