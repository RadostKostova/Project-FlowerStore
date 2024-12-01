using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Extensions;

namespace FlowerStore.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    /// Custom additional page model that allows the current User to see all orders he made.
    /// </summary>

    public class MyOrdersModel : PageModel
    {
        private readonly IOrderService orderService;

        public IEnumerable<OrderDetailsViewModel> Orders { get; set; } = new List<OrderDetailsViewModel>();

        public MyOrdersModel(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        //Display all orders of the current user
        public async Task<IActionResult> OnGetAsync()
        {
            var userId = User.GetUserId();
            Orders = await orderService.GetAllOrdersByUserIdAsync(userId);

            return Page();
        }
    }
}
