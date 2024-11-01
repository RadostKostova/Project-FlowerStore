using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Core.ViewModels.OrderProduct;
using FlowerStore.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace FlowerStore.Controllers
{
    /// <summary>
    /// The OrderController handles operations related to placing an order, such as choosing payment method, 
    /// add details to order, shipping info and etc. 
    /// </summary>

    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;

        public OrderController(IOrderService _orderService,
            ICartService _cartService)
        {
            orderService = _orderService;
            cartService = _cartService;
        }

        //Get detailed information of order
        [HttpGet]
        public async Task<IActionResult> OrderDetails(int id)
        {
            var orderFound = await orderService.OrderByIdExistAsync(id);

            if (orderFound == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var model = await orderService.GetOrderDetailsAsync(orderFound.Id);
            return View(model);
        }

        //Display form for collecting user input data
        [HttpGet]
        public async Task<IActionResult> ShippingDetails()
        {
            var model = new OrderFormViewModel
            {
                PaymentMethods = await orderService.GetAllPaymentMethodsAsync()
            };

            return View(model);
        }

        //Create new order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShippingDetails(OrderFormViewModel formModel)
        {
            if (!ModelState.IsValid)
            {
                formModel.PaymentMethods = await orderService.GetAllPaymentMethodsAsync();
                return View(formModel);
            }

            var userId = User.GetUserId();
            var cart = await cartService.GetOrCreateShoppingCartAsync(userId);

            var orderModel = new OrderCreateViewModel()
            {
                UserId = userId,
                ShippingAddress = formModel.ShippingAddress,
                OrderDetails = string.IsNullOrEmpty(formModel.OrderDetails) ? " " : formModel.OrderDetails,
                PaymentMethodId = formModel.PaymentMethodId,
                OrderDate = DateTime.Now,
                OrderStatusId = 1,
                ShoppingCartId = cart.Id,
                TotalPrice = orderService.CalculateTotalPrice(cart),
                PaymentMethods = await orderService.GetAllPaymentMethodsAsync(),
                OrderStatuses = await orderService.GetAllOrderStatusesAsync(),
                OrderProducts = cart.ShoppingCartProducts.Select(scp => new OrderProductViewModel
                {
                    OrderId = formModel.Id,
                    ProductId = scp.ProductId,
                    Price = scp.Price,
                    Quantity = scp.Quantity
                })
                .ToList()
            };

            if (!ModelState.IsValid)
            {
                orderModel.OrderStatuses = await orderService.GetAllOrderStatusesAsync();
                orderModel.PaymentMethods = await orderService.GetAllPaymentMethodsAsync();
                return View(orderModel);
            }

            var newOrderId = await orderService.CreateOrderAsync(orderModel);
            //await cartService.ClearCartAsync(userId); //after confirm
            return RedirectToAction(nameof(OrderDetails), new { id = newOrderId });
        }
    }
}
