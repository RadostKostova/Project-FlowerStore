using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Core.ViewModels.User;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using FlowerStore.Infrastructure.Data.Models.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Core.Services
{
    /// <summary>
    /// The admin service class includes methods for user management, administrative tasks, adding/editing products and etc.
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

        //Get all orders
        public async Task<IEnumerable<OrderAllViewModel>> GetAllOrdersAsync()
        {
            return await repository
                .AllAsReadOnly<Order>()
                .Include(o => o.PaymentMethod)
                .Include(o => o.OrderStatus)
                .Select(o => new OrderAllViewModel
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    OrderDate = o.OrderDate.ToString(),
                    TotalPrice = o.TotalPrice,
                    PaymentMethod = o.PaymentMethod.Name,
                    OrderDetails = o.OrderDetails,
                    ShippingAddress = o.ShippingAddress,
                    OrderStatus = o.OrderStatus.OrderStatusName,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    Email = o.Email,
                    Phone = o.Phone
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<UserAllViewModel>> GetAllUsersAsync()
        {
            var users = await userManager.Users
                .Select(user => new UserAllViewModel
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber
                })
                .ToListAsync();

            return users;
        }
    }
}
