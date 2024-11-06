using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Core.ViewModels.OrderProduct;
using FlowerStore.Extensions;
using Microsoft.AspNetCore.Mvc;


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
        public async Task<IActionResult> ShippingDetails()  //keeps model in invalid state
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
            if (formModel == null)  //add validation for empty ShippingAddress
            {
                return BadRequest();
            }

            var userId = User.GetUserId();
            var cart = await cartService.GetOrCreateShoppingCartAsync(userId);

            var orderModel = new OrderCreateViewModel()
            {
                UserId = userId,
                ShippingAddress = formModel.ShippingAddress,
                OrderDetails = formModel.OrderDetails,
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
                    ProductName = scp.Product.Name,
                    Price = scp.Price,
                    Quantity = scp.Quantity
                }).ToList()
            };

            if (!ModelState.IsValid)
            {
                orderModel.OrderStatuses = await orderService.GetAllOrderStatusesAsync();
                orderModel.PaymentMethods = await orderService.GetAllPaymentMethodsAsync();
                return View(orderModel);
            }
            
            var newOrderId = await orderService.CreateOrderAsync(orderModel);
            return RedirectToAction(nameof(OrderDetails), new { id = newOrderId });
        }

        //Get edit shipping details form
        [HttpGet]
        public async Task<IActionResult> EditOrder(int id)
        {
            var orderDetails = await orderService.GetOrderDetailsAsync(id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            var model = new OrderEditViewModel
            {
                Id = orderDetails.Id,
                ShippingAddress = orderDetails.ShippingAddress,
                OrderDetails = orderDetails.OrderDetails,
                PaymentMethodId = orderDetails.PaymentMethodId,
                PaymentMethods = await orderService.GetAllPaymentMethodsAsync()
            };

            return View(model);
        }

        //Post the updated order data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOrder(OrderEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.PaymentMethods = await orderService.GetAllPaymentMethodsAsync();
                return View(model);
            }

            var result = await orderService.UpdateOrderAsync(model);

            if (result == false)
            {
                ModelState.AddModelError(string.Empty, "Error updating order.");
                model.PaymentMethods = await orderService.GetAllPaymentMethodsAsync();
                return View(model);
            }
            return RedirectToAction("OrderDetails", new { id = model.Id });
        }

        //Confirm the order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirm(int id)
        {
            var userId = User.GetUserId();
            var order = await orderService.OrderByIdExistAsync(id);

            if (order == null || order.UserId != userId || order.OrderStatusId != 1)
            {
                return NotFound();
            }

            var isConfirmed = await orderService.ConfirmOrderAsync(id);
            if (!isConfirmed)
            {
                TempData["ErrorMessage"] = "Unable to confirm the order.";
                return RedirectToAction("OrderDetails", new { id });
            }

            await cartService.ClearCartAsync(userId);

            TempData["SuccessMessage"] = "Order confirmed successfully.";
            return RedirectToAction("OrderHistoryAll");
        }

        [HttpGet]
        public async Task<IActionResult> OrderHistoryAll()
        {
            var allOrders = await orderService.GetAllOrdersAsync();
            return View(allOrders);
        }
    }
}
