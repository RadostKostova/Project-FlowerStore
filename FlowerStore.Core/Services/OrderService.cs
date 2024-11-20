using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.CardDetails;
using FlowerStore.Core.ViewModels.Cart;
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
    /// Order service for handling operations related to Order
    /// </summary>

    public class OrderService : IOrderService
    {
        private readonly IRepository repository;
        private readonly ICartService cartService;
        private readonly IProductService productService;

        public OrderService(IRepository _repository,
            ICartService _cartService,
            IProductService _productService)
        {
            repository = _repository;
            cartService = _cartService;
            productService = _productService;
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
            var payments = await repository
                .AllAsReadOnly<PaymentMethod>()
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
            var orderStatuses = await repository
                .AllAsReadOnly<OrderStatus>()
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
            var orderModel = new OrderViewModel
            {
                UserId = cart.UserId,
                ShippingAddress = formModel.ShippingAddress,
                OrderDetails = formModel.OrderDetails,
                PaymentMethodId = formModel.PaymentMethodId,
                OrderDate = DateTime.Now,
                OrderStatusId = 1,  //Pending
                ShoppingCartId = cart.Id,
                TotalPrice = CalculateTotalPrice(await cartService.ShoppingCartExistByUserIdAsync(cart.UserId)),
                PaymentMethods = await GetAllPaymentMethodsAsync(),
                OrderStatuses = await GetAllOrderStatusesAsync(),
                FirstName = formModel.FirstName,
                LastName = formModel.LastName,
                Phone = formModel.Phone,
                Email = formModel.Email,
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

        //Create new order in database (and decrease the quantity of product in stock)
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
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                Email = model.Email,
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

            foreach (var orderedProduct in orderedProducts)
            {
                await productService.UpdateProductStockAsync(orderedProduct.ProductId, orderedProduct.Quantity);
            }

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

        //Calculating total price from entity for precision
        public decimal CalculateTotalPrice(ShoppingCart cart)
        {
            return cart.ShoppingCartProducts.Sum(p => p.Price * p.Quantity);
        }
    }
}

