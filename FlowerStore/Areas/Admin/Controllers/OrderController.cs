using FlowerStore.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Areas.Admin.Controllers
{
    public class OrderController : AdminBaseController
    {
        /// <summary>
        /// Manages operations related to orders.
        /// </summary>
        
        private readonly IAdminService adminService;

        public OrderController(IAdminService _adminService)
        {
            adminService = _adminService;
        }
        
        //Get all orders
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allOrders = await adminService.GetAllOrdersAsync();
            return View(allOrders);
        }
    }
}
