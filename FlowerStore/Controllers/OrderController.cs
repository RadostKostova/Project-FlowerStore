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
    /// The main target of the controller is first to collect the needed user input data (as viewModels) in session (in-memory session store) and then to create actual order at the database. COMMENTS PROVIDED!
    /// </summary>
    
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;
        private readonly IUserService userService;

        public OrderController(IOrderService _orderService,
            ICartService _cartService,
            IUserService _userService)
        {
            orderService = _orderService;
            cartService = _cartService;
            userService = _userService;
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
        public async Task<IActionResult> ShippingDetails(OrderFormViewModel formModel)
        {
            if (!ModelState.IsValid)
            {
                formModel.PaymentMethods = await orderService.GetAllPaymentMethodsAsync();
                return View(formModel);
            }

            //Save the shipping input data to session for future display (at Preview())
            HttpContext.Session.SetString("OrderFormViewModel", JsonConvert.SerializeObject(formModel));

            var paymentChosen = await orderService.GetChosenPaymentMethodAsync(formModel.PaymentMethodId);

            if (paymentChosen.Name == "Card") //if "Card" payment -> go to card form
            {
                return RedirectToAction(nameof(CardDetails));
            }

            return RedirectToAction(nameof(Preview)); //if "Cash" payment -> go to Preview() and skip card form
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
        public IActionResult CardDetails(CardDetailsAddViewModel cardModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cardModel);
            }

            //Save the card input data to session for future display (at Preview())
            HttpContext.Session.SetString("CardDetailsAddViewModel", JsonConvert.SerializeObject(cardModel));
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

            var formModelJson = HttpContext.Session.GetString("OrderFormViewModel");  

            if (string.IsNullOrEmpty(formModelJson))  //something occured, try again
            {
                return RedirectToAction(nameof(ShippingDetails));
            }

            var formModel = JsonConvert.DeserializeObject<OrderFormViewModel>(formModelJson); //retrieve user's shipping details input

            var cart = await cartService.GetShoppingCartByUserIdAsync(User.GetUserId());
            var orderModel = await orderService.CreateOrderViewModelAsync(formModel, cart);  //create order viewModel

            if (orderModel == null)
            {
                return BadRequest();
            }

            if (HttpContext.Session.Keys.Contains("CardDetailsAddViewModel")) //check if user chosen card payment
            {
                var cardModelJson = HttpContext.Session.GetString("CardDetailsAddViewModel");

                if (string.IsNullOrEmpty(cardModelJson)) //something occured, try again
                {
                    return RedirectToAction(nameof(CardDetails));
                }

                var cardModel = JsonConvert.DeserializeObject<CardDetailsAddViewModel>(cardModelJson);

                orderModel.CardDetails = cardModel;   //attach the card details to the view model
            }

            HttpContext.Session.Remove("OrderFormViewModel");  //clear session from previous view models
            HttpContext.Session.Remove("CardDetailsAddViewModel");

            HttpContext.Session.SetString("OrderViewModel", JsonConvert.SerializeObject(orderModel)); //save the new detailed order
            return View(orderModel);
        }

        //Create new actual order in database (and eventual CardDetails)
        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            var orderModel = JsonConvert.DeserializeObject<OrderViewModel>(HttpContext.Session.GetString("OrderViewModel"));

            if (orderModel == null || !ModelState.IsValid)  //something occured, try again
            {
                return View(nameof(Preview));
            }

            int? cardId = null;  
            if (orderModel.CardDetails != null) //if user choose card payment -> create it
            {
                 cardId = await orderService.CreateCardDetailsAsync(orderModel.CardDetails);
            }

            var newOrderId = await orderService.CreateOrderAsync(orderModel, cardId); //create order in db

            if (newOrderId == 0) //something occured, try again
            {
                return View(nameof(Preview));
            }

            await userService.UpdateUserInfoAsync(User.GetUserId()); //update first, last name and phone in AspNetUsers

            HttpContext.Session.Remove("OrderViewModel");  //clear both session and cart
            await cartService.ClearCartAsync(User.GetUserId());
            return RedirectToAction("Confirmed", new { orderId = newOrderId });
        }

        //Display confirmed page
        [HttpGet]
        public async Task<IActionResult> Confirmed(int orderId)
        {
            var order = await orderService.OrderByIdExistAsync(orderId);

            if (order == null)
            {
                return NotFound();
            }

            if (order.UserId != User.GetUserId())
            {
                return Unauthorized();
            }

            ViewBag.OrderId = order.Id;
            ViewBag.OrderDate = order.OrderDate;
            return View();
        }
    }
}
