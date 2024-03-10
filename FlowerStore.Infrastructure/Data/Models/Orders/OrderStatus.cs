using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Infrastructure.Data.Models.Orders.Order
{
    /// <summary>
    /// Represents the status of the order.  
    /// </summary>

    public class OrderStatus
    {
        [Key]
        [Comment("Order status identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(OrderStatusMaxLength)]
        [Comment("Name of the order status")]
        public string OrderStatusName { get; set; } = string.Empty;
    }
}
