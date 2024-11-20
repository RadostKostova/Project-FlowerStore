using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Core.ViewModels.OrderStatus;
using FlowerStore.Core.ViewModels.User;

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
    }
}
