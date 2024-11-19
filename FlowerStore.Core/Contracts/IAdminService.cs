using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Core.ViewModels.User;

namespace FlowerStore.Core.Contracts
{
    /// <summary>
    /// Interface for admin services.
    /// </summary>
   
    public interface IAdminService
    {
        Task<IEnumerable<OrderAllViewModel>> GetAllOrdersAsync();
        Task<OrderDetailsViewModel> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<UserAllViewModel>> GetAllUsersAsync();
    }
}
