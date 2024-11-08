using FlowerStore.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Areas.Admin.Controllers
{
    public class OrderController : AdminBaseController
    {
        /// <summary>
        /// Manages operations related to orders and admin
        /// </summary>
        
        private readonly IOrderService orderService;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }
        
        //Get all orders
        [HttpGet]
        public async Task<IActionResult> OrderHistoryAll()
        {
            var allOrders = await orderService.GetAllOrdersAsync();
            return View(allOrders);
        }
    }
}
