using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Core.ViewModels.OrderProduct;
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
                    OrderDate = o.OrderDate,
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

        //Get order by id
        public async Task<OrderDetailsViewModel> GetOrderByIdAsync(int orderId)
        {
            var order = await repository
                .AllAsReadOnly<Order>()
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .Include(o => o.OrderStatus)
                .Include(o => o.PaymentMethod)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            var model = new OrderDetailsViewModel
            {
                OrderId = order.Id,
                UserId = order.UserId,
                FirstName = order.FirstName,
                LastName = order.LastName,
                Email = order.Email,
                Phone = order.Phone,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                OrderDetails = order.OrderDetails ?? string.Empty,
                ShippingAddress = order.ShippingAddress,
                OrderStatus = order.OrderStatus.OrderStatusName,
                PaymentMethod = order.PaymentMethod.Name,
                OrderProducts = order.OrderProducts.Select(op => new OrderProductViewModel
                {
                    OrderId = op.OrderId,
                    ProductId = op.ProductId,
                    ProductName = op.ProductName,
                    Quantity = op.Quantity,
                    Price = op.Price
                }).ToList()
            };

            return model;
        }

        //Get all users
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
