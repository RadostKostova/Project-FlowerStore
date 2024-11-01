using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Core.ViewModels.OrderProduct;
using FlowerStore.Core.ViewModels.OrderStatus;
using FlowerStore.Core.ViewModels.PaymentMethod;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data.Models.Cart;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using FlowerStore.Infrastructure.Data.Models.Payment;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Core.Services
{
    /// <summary>
    /// Order service for handling operations in Order section
    /// </summary>

    public class OrderService : IOrderService
    {
        private readonly IRepository repository;
        private readonly ICartService cartService;

        public OrderService(IRepository _repository,
            ICartService _cartService)
        {
            repository = _repository;
            cartService = _cartService;
        }

        //Check if Order exist by id and return it as Order entity
        public async Task<Order> OrderByIdExistAsync(int orderId)
        {
            var orderFound = await repository
                .AllAsReadOnly<Order>()
                .Include(o => o.ShoppingCart)
                .ThenInclude(sc => sc.ShoppingCartProducts)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            return orderFound;
        }

        //Get all payment methods from database
        public async Task<IEnumerable<PaymentMethodViewModel>> GetAllPaymentMethodsAsync()
        {
            var payments = await repository.AllAsReadOnly<PaymentMethod>()
                .Select(p => new PaymentMethodViewModel()
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();

            return payments;
        }

        //Get all order statuses from database
        public async Task<IEnumerable<OrderStatusViewModel>> GetAllOrderStatusesAsync()
        {
            var orderStatuses = await repository.AllAsReadOnly<OrderStatus>()
                .Select(os => new OrderStatusViewModel()
                {
                    Id = os.Id,
                    OrderStatusName = os.OrderStatusName
                })
                .ToListAsync();

            return orderStatuses;
        }

        //Create order in database
        public async Task<int> CreateOrderAsync(OrderCreateViewModel model)
        {
            var cart = await cartService.GetOrCreateShoppingCartAsync(model.UserId);

            var order = new Order
            {
                UserId = model.UserId,
                OrderDate = model.OrderDate,
                TotalPrice = CalculateTotalPrice(cart),
                OrderDetails = model.OrderDetails,
                ShippingAddress = model.ShippingAddress,
                OrderStatusId = model.OrderStatusId,
                PaymentMethodId = model.PaymentMethodId,
                ShoppingCartId = model.ShoppingCartId,
            };

            await repository.AddAsync(order);
            await repository.SaveChangesAsync();

            var orderedProducts = cart.ShoppingCartProducts.Select(cp => new OrderProduct
            {
                OrderId = order.Id,
                ProductId = cp.ProductId,
                Quantity = cp.Quantity,
                Price = cp.Price
            }).ToList();

            order.ShoppingCart = cart;
            order.OrderProducts = orderedProducts;
            await repository.SaveChangesAsync();

            return order.Id;
        }

        //Get full information about order details
        public async Task<OrderDetailsViewModel> GetOrderDetailsAsync(int orderId)
        {
            var model = await OrderByIdExistAsync(orderId);

            var paymentFound = await repository
                .AllAsReadOnly<PaymentMethod>()
                .FirstOrDefaultAsync(p => p.Id == model.PaymentMethodId);

            var orderStatusFound = await repository
                .AllAsReadOnly<OrderStatus>()
                .FirstOrDefaultAsync(os => os.Id == model.OrderStatusId);

            var newOrder = new OrderDetailsViewModel()
            {
                Id = model.Id,
                UserId = model.UserId,
                OrderDate = model.OrderDate,
                TotalPrice = model.TotalPrice,
                OrderDetails = model.OrderDetails,
                ShippingAddress = model.ShippingAddress,
                ShoppingCartId = model.ShoppingCartId,
                PaymentMethodId = model.PaymentMethodId,
                OrderStatusId = model.OrderStatusId,
                OrderProducts = model.ShoppingCart.ShoppingCartProducts.Select(scp => new OrderProductViewModel
                {
                    OrderId = model.Id,
                    ProductId = scp.ProductId,
                    Price = scp.Price,
                    Quantity = scp.Quantity
                }).ToList()
            };

            return newOrder;
        }

        public decimal CalculateTotalPrice(ShoppingCart cart)
        {
            return cart.ShoppingCartProducts.Sum(p => p.Price * p.Quantity);
        }

    }
}
