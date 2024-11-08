using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Core.ViewModels.OrderHistory;
using FlowerStore.Core.ViewModels.OrderStatus;
using FlowerStore.Core.ViewModels.PaymentMethod;
using FlowerStore.Infrastructure.Data.Models.Cart;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;

namespace FlowerStore.Core.Contracts
{
    /// <summary>
    /// Interface for Order services.
    /// </summary>

    public interface IOrderService
    {
        Task<IEnumerable<PaymentMethodViewModel>> GetAllPaymentMethodsAsync();
        Task<IEnumerable<OrderStatusViewModel>> GetAllOrderStatusesAsync();
        Task<Order> OrderByIdExistAsync(int orderId);
        Task<OrderViewModel> CreateOrderViewModel(OrderFormViewModel formModel, ShoppingCart cart);
        Task<int> CreateOrderAsync(OrderViewModel model);

        Task<OrderDetailsViewModel> GetOrderDetailsAsync(int orderId);
        Task<bool> UpdateOrderAsync(OrderFormViewModel model);
        Task<bool> ConfirmOrderAsync(int orderId);
        Task<int> CreateOrderHistoryAsync(int orderId);
        decimal CalculateTotalPrice(ShoppingCart cart);
        Task<IEnumerable<OrderHistoryViewModel>> GetAllOrdersAsync();

        //Task<bool> AddProductToOrderAsync(int orderId, int productId, int quantity);
        //Task<bool> RemoveProductFromOrderAsync(int orderId, int productId);
        //Task<bool> SaveAsync();
    }
}
