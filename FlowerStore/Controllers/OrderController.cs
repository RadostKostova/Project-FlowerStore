using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Core.ViewModels.OrderProduct;
using FlowerStore.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace FlowerStore.Controllers
{
    /// <summary>
    /// The OrderController handles operations related to placing an order, such as choosing payment method, shipping info and etc. 
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

        //Display form for collecting user input data
        [HttpGet]
        public async Task<IActionResult> ShippingDetails()
        {
            if (await cartService.IsShoppingCartEmpty(User.GetUserId()))
            {
                return BadRequest();
            }

            var model = new OrderFormViewModel
            {
                PaymentMethods = await orderService.GetAllPaymentMethodsAsync()
            };

            //Get previous user data input in case user clicked "Edit"
            if (TempData.ContainsKey("OrderFormData"))
            {
                var previousData = JsonConvert.DeserializeObject<OrderFormViewModel>(TempData["OrderFormData"].ToString());
                model.ShippingAddress = previousData.ShippingAddress;
                model.OrderDetails = previousData.OrderDetails;
                model.PaymentMethodId = previousData.PaymentMethodId;
            }
            return View(model);
        }

        //Get user input data for further usage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShippingDetails(OrderFormViewModel formModel)
        {
            if (!ModelState.IsValid)
            {
                formModel.PaymentMethods = await orderService.GetAllPaymentMethodsAsync();
                return View(formModel);
            }
            return RedirectToAction(nameof(Preview), formModel);
        }

        //Get detailed information of order and create viewModel
        [HttpGet]
        public async Task<IActionResult> Preview(OrderFormViewModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cart = await cartService.GetOrCreateShoppingCartAsync(User.GetUserId());
            var orderModel = await orderService.CreateOrderViewModel(formModel, cart);

            if (orderModel == null)
            {
                return BadRequest();
            }

            //Saving temporary data if user decides to edit the form
            TempData["OrderFormData"] = JsonConvert.SerializeObject(formModel);
            return View(orderModel);
        }

        //Create new order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(OrderViewModel model)
        {
            //clear tempData

            if (!ModelState.IsValid)
            {
                model.PaymentMethods = await orderService.GetAllPaymentMethodsAsync();
                model.OrderStatuses = await orderService.GetAllOrderStatusesAsync();
                return View(nameof(Preview), model);
            }

            var newOrderId = await orderService.CreateOrderAsync(model);

            if (newOrderId == 0)
            {
                ModelState.AddModelError("", "There was an issue creating your order. Please try again.");
                return View(nameof(Preview), model);
            }

            await cartService.ClearCartAsync(User.GetUserId());
            return RedirectToAction("OrderConfirmation", new { id = newOrderId });
        }
    }
}
