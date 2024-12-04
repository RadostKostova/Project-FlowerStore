using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Areas.Admin.Controllers
{
    public class OrderController : AdminBaseController
    {
        /// <summary>
        /// Manages operations related to orders.
        /// </summary>
        
        private readonly IAdminService adminService;
        private readonly IOrderService orderService;

        public OrderController(IAdminService _adminService, 
            IOrderService _orderService)
        {
            adminService = _adminService;
            orderService = _orderService;
        }

        //Display all orders with pagination (handles unexisting page)
        [HttpGet]
        public async Task<IActionResult> All(int page = 1, int pageSize = 6)
        {
            var orders = await adminService.GetPaginatedOrdersAsync(page, pageSize);

            if (page < 1 || page > orders.TotalPages && orders.TotalPages > 0)
            {
                return RedirectToAction(nameof(All), new { page = 1 });
            }           
            
            return View(orders);
        }

        //Get details of order
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var order = await adminService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        //Display status of order
        [HttpGet]
        public async Task<IActionResult> EditStatus(int id)
        {
            var model = await adminService.GetOrderForStatusEditing(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        //Change status of order
        [HttpPost]
        public async Task<IActionResult> EditStatus(OrderEditStatusViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.OrderStatuses = await orderService.GetAllOrderStatusesAsync();
                return View(model);
            }

            //var order = await adminService.GetOrderForStatusEditing(model.OrderId);

            var isStatusEdited = await adminService.EditStatusAsync(model.OrderId, model.SelectedStatusId);

            if (!isStatusEdited)
            {
                return BadRequest();
            }

            return RedirectToAction("Details", new { id = model.OrderId });
        }
    }
}
