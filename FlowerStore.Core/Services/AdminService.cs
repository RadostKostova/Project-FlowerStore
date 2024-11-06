using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.OrderHistory;
using FlowerStore.Core.ViewModels.OrderProduct;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using FlowerStore.Infrastructure.Data.Models.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Core.Services
{
    /// <summary>
    /// The admin service class includes methods for user management and administrative tasks.
    /// </summary>

    public class AdminService : IAdminService
    {
        private readonly IRepository repository;
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminService(IRepository _repository,
            IUserService _userService,
            UserManager<ApplicationUser> _userManager)
        {
            repository = _repository;
            userService = _userService;
            userManager = _userManager;
        }

        //Get all orders (order history of all users)
        public async Task<IEnumerable<OrderHistoryViewModel>> GetAllOrdersAsync()
        {
            return await repository
                .AllAsReadOnly<OrderHistory>()
                .Select(oh => new OrderHistoryViewModel
                {
                    Id = oh.Id,
                    UserId = oh.UserId,
                    OrderId = oh.OrderId,
                    OrderDate = oh.OrderDate,
                    TotalPrice = oh.TotalPrice,
                    ShippingAddress = oh.ShippingAddress,
                    PaymentMethod = oh.PaymentMethod.Name,
                    OrderStatus = oh.OrderStatus.OrderStatusName,
                    OrderProducts = oh.OrderProducts.Select(op => new OrderProductViewModel
                    {
                        ProductId = op.ProductId,
                        ProductName = op.ProductName,
                        Price = op.Price,
                        Quantity = op.Quantity
                    }).ToList()
                })
                .ToListAsync();
        }


    }
}
