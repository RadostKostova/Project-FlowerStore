using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.CardDetails;
using FlowerStore.Core.ViewModels.Order;
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

        //Display form for shipping information
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

            return View(model);
        }

        //Retrieve user input (shipping info) and redirect based on payment method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShippingDetails(OrderFormViewModel formModel)
        {
            if (!ModelState.IsValid)
            {
                formModel.PaymentMethods = await orderService.GetAllPaymentMethodsAsync();
                return View(formModel);
            }

            TempData["OrderFormData"] = JsonConvert.SerializeObject(formModel); //save for Preview()
            var paymentChosen = await orderService.GetChosenPaymentMethodAsync(formModel.PaymentMethodId);

            if (paymentChosen.Name == "Card")
            {
                return RedirectToAction(nameof(CardDetails));
            }
            return RedirectToAction(nameof(Preview));
        }

        //Display form for card-chosen payment
        [HttpGet]
        public async Task<IActionResult> CardDetails()
        {
            if (await cartService.IsShoppingCartEmpty(User.GetUserId()))
            {
                return BadRequest();
            }

            var model = new CardDetailsAddViewModel
            {
                UserId = User.GetUserId()
            };
            return View(model);
        }

        //Retrieve user's card details and redirect to Preview
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CardDetails(CardDetailsAddViewModel cardModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cardModel);
            }
           
            TempData["CardDetailsData"] = JsonConvert.SerializeObject(cardModel); //save for Preview()
            return RedirectToAction(nameof(Preview));
        }

        //Show collected order's data and create new detailed viewModel (before placing new order)
        [HttpGet]
        public async Task<IActionResult> Preview()
        {
            if (await cartService.IsShoppingCartEmpty(User.GetUserId()))
            {
                return BadRequest();
            }

            var formModel = JsonConvert.DeserializeObject<OrderFormViewModel>(TempData["OrderFormData"]?.ToString());

            if (formModel == null)
            {
                return RedirectToAction(nameof(ShippingDetails));
            }

            var cart = await cartService.GetShoppingCartByUserIdAsync(User.GetUserId());
            var orderModel = await orderService.CreateOrderViewModelAsync(formModel, cart); 

            if (orderModel == null)
            {
                return BadRequest();
            }

            if (TempData.ContainsKey("CardDetailsData"))
            {   
                var cardModel = JsonConvert.DeserializeObject<CardDetailsAddViewModel>(TempData["CardDetailsData"]?.ToString());

                if (cardModel == null)
                {
                    return RedirectToAction(nameof(CardDetails));
                }
                orderModel.CardDetails = cardModel;                 
            }

            TempData["OrderViewModel"] = JsonConvert.SerializeObject(orderModel);
            return View(orderModel);
        }

        //Create new actual order in database (and eventual CardDetails)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder()
        {
            var orderModel = JsonConvert.DeserializeObject<OrderViewModel>(TempData["OrderViewModel"].ToString());

            if (orderModel == null || !ModelState.IsValid)
            {
                return View(nameof(Preview));
            }

            int? cardId = null;
            if (orderModel.CardDetails != null)
            {
                 cardId = await orderService.CreateCardDetailsAsync(orderModel.CardDetails);
            }

            var newOrderId = await orderService.CreateOrderAsync(orderModel, cardId);

            if (newOrderId == 0)
            {
                ModelState.AddModelError("", "There was an issue creating your order. Please try again.");
                return View(nameof(Preview));
            }

            TempData.Clear();
            await cartService.ClearCartAsync(User.GetUserId());
            return RedirectToAction("Confirmed", new { orderId = newOrderId });
        }

        [HttpGet]
        public async Task<IActionResult> Confirmed(int orderId)
        {
            var order = await orderService.OrderByIdExistAsync(orderId);
            //TODO: change orderStatus

            if (order == null)
            {
                return NotFound("Order not found.");
            }

            if (order.UserId != User.GetUserId())
            {
                return Unauthorized();
            }

            ViewBag.OrderId = orderId;
            return View();
        }
    }
}
