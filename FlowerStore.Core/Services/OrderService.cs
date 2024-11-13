using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.CardDetails;
using FlowerStore.Core.ViewModels.Cart;
using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Core.ViewModels.OrderHistory;
using FlowerStore.Core.ViewModels.OrderProduct;
using FlowerStore.Core.ViewModels.OrderStatus;
using FlowerStore.Core.ViewModels.PaymentMethod;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data.Models.Cart;
using FlowerStore.Infrastructure.Data.Models.Orders;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using FlowerStore.Infrastructure.Data.Models.Payment;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Core.Services
{
    /// <summary>
    /// Order service for handling operations related to Order
    /// </summary>

    public class OrderService : IOrderService
    {
        private readonly IRepository repository;
        private readonly ICartService cartService;
        private readonly IUserService userService;

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
                .ThenInclude(scp => scp.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            return orderFound;
        }

        //Get all payment methods from database as view models
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

        //Get all order statuses from database as view models
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

        //Get payment method from database by id
        public async Task<PaymentMethod> GetChosenPaymentMethodAsync(int paymentId)
        {
            var payment = await repository
                .AllAsReadOnly<PaymentMethod>()
                .FirstOrDefaultAsync(pm => pm.Id == paymentId);

            return payment!;
        }

        //Collect all order data with user input data and create OrderViewModel
        public async Task<OrderViewModel> CreateOrderViewModelAsync(OrderFormViewModel formModel, CartViewModel cart)
        {
            var cartFound = await cartService.ShoppingCartExistByUserIdAsync(cart.UserId);

            var orderModel = new OrderViewModel
            {
                UserId = cart.UserId,
                ShippingAddress = formModel.ShippingAddress,
                OrderDetails = formModel.OrderDetails,
                PaymentMethodId = formModel.PaymentMethodId,
                OrderDate = DateTime.Now,
                OrderStatusId = 1,  //Pending
                ShoppingCartId = cart.Id,
                TotalPrice = CalculateTotalPrice(cartFound),
                PaymentMethods = await GetAllPaymentMethodsAsync(),
                OrderStatuses = await GetAllOrderStatusesAsync(),
                OrderProducts = cart.ShoppingCartProducts.Select(scp => new OrderProductViewModel
                {
                    OrderId = formModel.Id,
                    ProductId = scp.ProductId,
                    ProductName = scp.Name,
                    Price = scp.UnitPrice,
                    Quantity = scp.Quantity
                }).ToList()
            };

            return orderModel;
        }

        //Create new order in database
        public async Task<int> CreateOrderAsync(OrderViewModel model, int? cardDetailsId = null)
        {
            var cart = await cartService.ShoppingCartExistByUserIdAsync(model.UserId);

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
                CardDetailsId = cardDetailsId,
            };

            await repository.AddAsync(order);
            await repository.SaveChangesAsync();

            var orderedProducts = cart.ShoppingCartProducts.Select(cp => new OrderProduct
            {
                OrderId = order.Id,
                ProductId = cp.ProductId,
                ProductName = cp.Product.Name,
                Quantity = cp.Quantity,
                Price = cp.Price
            }).ToList();

            order.ShoppingCart = cart;
            order.OrderProducts = orderedProducts;
            await repository.SaveChangesAsync();

            return order.Id;
        }

        //Create new card details in database
        public async Task<int> CreateCardDetailsAsync(CardDetailsAddViewModel model)
        {
            var newCard = new CardDetails
            {
                UserId = model.UserId,
                CardHolderName = model.CardHolderName,
                CardNumber = model.CardNumber,
                ExpirationDate = model.ExpirationDate,
                CVV = model.CVV
            };

            await repository.AddAsync(newCard);
            await repository.SaveChangesAsync();
            return newCard.Id;
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
                    ProductName = scp.Product.Name,
                    Price = scp.Price,
                    Quantity = scp.Quantity
                }).ToList()
            };
            return newOrder;
        }

        //Update order after edit and return boolean
        public async Task<bool> UpdateOrderAsync(OrderFormViewModel model)
        {
            var order = await OrderByIdExistAsync(model.Id);
            if (order == null)
            {
                return false;
            }

            var payments = await GetAllPaymentMethodsAsync();

            if (!payments.Any(p => p.Id == model.PaymentMethodId))
            {
                return false;
            }

            order.ShippingAddress = model.ShippingAddress;
            order.OrderDetails = model.OrderDetails;
            order.PaymentMethodId = model.PaymentMethodId;

            await repository.SaveChangesAsync();
            return true;
        }

        //Confirm the order, change order status and return boolean
        public async Task<bool> ConfirmOrderAsync(int orderId)
        {
            var order = await repository.All<Order>()
                .Include(o => o.OrderProducts)
                .FirstOrDefaultAsync(o => o.Id == orderId && o.OrderStatusId == 1);

            if (order == null)
            {
                return false;
            }

            var shippedStatus = await repository.All<OrderStatus>()
                .FirstOrDefaultAsync(os => os.OrderStatusName == "Shipped");

            order.OrderStatusId = shippedStatus!.Id;
            await repository.SaveChangesAsync();
            return true;
        }

        //Get current user order
        //public async Task<Order?> GetUserPendingOrderAsync(string userId)
        //{
        //    return await repository.AllAsReadOnly<Order>()
        //        .FirstOrDefaultAsync(o => o.UserId == userId && o.OrderStatus.OrderStatusName == "Pending");
        //}

        //Add Order to OrderHistory
        public async Task<int> CreateOrderHistoryAsync(int orderId)
        {
            var order = await OrderByIdExistAsync(orderId);

            if (order == null)
            {
                throw new ArgumentException("Order not found");
            }

            var orderHistory = new OrderHistory
            {
                OrderId = order.Id,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                OrderDetails = order.OrderDetails ?? " ",
                ShippingAddress = order.ShippingAddress,
                TotalPrice = order.TotalPrice,
                PaymentMethodId = order.PaymentMethodId,
                OrderStatusId = order.OrderStatusId,
                OrderProducts = order.OrderProducts.Select(op => new OrderProductHistory
                {
                    ProductId = op.ProductId,
                    ProductName = op.Product.Name,
                    Price = op.Price,
                    Quantity = op.Quantity
                }).ToList()
            };

            await repository.AddAsync(orderHistory);
            await repository.SaveChangesAsync();

            return orderHistory.Id;
        }

        //Get all orders (admin only)
        public async Task<IEnumerable<OrderHistoryViewModel>> GetAllOrdersAsync()
        {
            return await repository
                .AllAsReadOnly<OrderHistory>()
                .Select(oh => new OrderHistoryViewModel
                {
                    Id = oh.Id,
                    UserId = oh.UserId,
                    OrderId = oh.OrderId,
                    OrderDate = oh.OrderDate,
                    TotalPrice = oh.TotalPrice,
                    ShippingAddress = oh.ShippingAddress,
                    PaymentMethod = oh.PaymentMethod.Name,
                    OrderStatus = oh.OrderStatus.OrderStatusName,
                    OrderProducts = oh.OrderProducts.Select(op => new OrderProductViewModel
                    {
                        ProductId = op.ProductId,
                        ProductName = op.ProductName,
                        Price = op.Price,
                        Quantity = op.Quantity
                    }).ToList()
                })
                .ToListAsync();
        }

        //Calculating total price from entity for precision
        public decimal CalculateTotalPrice(ShoppingCart cart)
        {
            return cart.ShoppingCartProducts.Sum(p => p.Price * p.Quantity);
        }
    }
}

