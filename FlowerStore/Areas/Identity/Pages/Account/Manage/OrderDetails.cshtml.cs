using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlowerStore.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    /// Custom additional page model for displaying the details of a single order of the current User.
    /// </summary>
    public class OrderDetailsModel : PageModel
    {
        private readonly IOrderService orderService;

        public OrderDetailsViewModel Order { get; set; } = null!;

        public OrderDetailsModel(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        //Display the details of the order
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var userId = User.GetUserId();
            var order = await orderService.GetOrderDetailsAsync(id, userId);

            if (order == null)
            {
                return NotFound();
            }

            Order = order;
            return Page();
        }
    }
}
