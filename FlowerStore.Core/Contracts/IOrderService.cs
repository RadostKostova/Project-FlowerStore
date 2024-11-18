using FlowerStore.Core.ViewModels.CardDetails;
using FlowerStore.Core.ViewModels.Cart;
using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Core.ViewModels.OrderStatus;
using FlowerStore.Core.ViewModels.PaymentMethod;
using FlowerStore.Infrastructure.Data.Models.Cart;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using FlowerStore.Infrastructure.Data.Models.Payment;

namespace FlowerStore.Core.Contracts
{
    /// <summary>
    /// Interface for Order services.
    /// </summary>

    public interface IOrderService
    {
        Task<IEnumerable<PaymentMethodViewModel>> GetAllPaymentMethodsAsync();
        Task<IEnumerable<OrderStatusViewModel>> GetAllOrderStatusesAsync();
        Task<PaymentMethod> GetChosenPaymentMethodAsync(int paymentId);
        Task<Order> OrderByIdExistAsync(int orderId);
        Task<OrderViewModel> CreateOrderViewModelAsync(OrderFormViewModel formModel, CartViewModel cart);
        Task<int> CreateCardDetailsAsync(CardDetailsAddViewModel model);
        Task<int> CreateOrderAsync(OrderViewModel model, int? cardId);
        decimal CalculateTotalPrice(ShoppingCart cart);

        //Task<bool> AddProductToOrderAsync(int orderId, int productId, int quantity);
        //Task<bool> RemoveProductFromOrderAsync(int orderId, int productId);
        //Task<bool> SaveAsync();
    }
}
