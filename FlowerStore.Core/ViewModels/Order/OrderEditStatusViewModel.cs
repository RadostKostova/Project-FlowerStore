using FlowerStore.Core.ViewModels.OrderStatus;
using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;
using static FlowerStore.Infrastructure.Constants.ErrorConstants;

namespace FlowerStore.Core.ViewModels.Order
{
    public class OrderEditStatusViewModel
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        [StringLength(OrderStatusMaxLength, 
            MinimumLength = OrderStatusMinLength, 
            ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Current status")]
        public string CurrentStatus { get; set; } = string.Empty;

        [Required]
        [Display(Name = "New status")]
        public int SelectedStatusId { get; set; }

        public IEnumerable<OrderStatusViewModel> OrderStatuses { get; set; } = new List<OrderStatusViewModel>();
    }
}
