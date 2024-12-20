﻿using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Admin;
using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Core.ViewModels.OrderProduct;
using FlowerStore.Core.ViewModels.OrderStatus;
using FlowerStore.Core.ViewModels.Product;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data.Models;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using FlowerStore.Infrastructure.Data.Models.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static FlowerStore.Core.Constants.AdminConstants;

namespace FlowerStore.Core.Services
{
    /// <summary>
    /// The admin service class includes methods for user managment, administrative tasks, adding/editing products and etc.
    /// </summary>

    public class AdminService : IAdminService
    {
        private readonly IRepository repository;
        private readonly IProductService productService;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminService(IRepository _repository,
            IProductService _productService,
            UserManager<ApplicationUser> _userManager)
        {
            repository = _repository;
            productService = _productService;
            userManager = _userManager;
        }

        //-----------------------------------------------------------------------------------------ORDER SERVICES:
        //Display all orders with pagination (not at orderService because only admin should see all orders)
        public async Task<OrdersPaginatedViewModel> GetPaginatedOrdersAsync(int page, int pageSize)
        {
            var ordersCount = await repository
                .AllAsReadOnly<Order>()
                .CountAsync();

            var totalPages = (int)Math.Ceiling((double)ordersCount / pageSize);

            var orders = await repository
                .AllAsReadOnly<Order>()
                .OrderByDescending(o => o.OrderDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new OrderAllViewModel
                {
                    Id = p.Id,
                    UserId = p.UserId,
                    OrderDate = p.OrderDate,
                    TotalPrice = p.TotalPrice,
                    PaymentMethod = p.PaymentMethod.Name,
                    OrderDetails = p.OrderDetails,
                    ShippingAddress = p.ShippingAddress,
                    OrderStatus = p.OrderStatus.OrderStatusName,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Email = p.Email,
                    PhoneNumber = p.PhoneNumber

                })
                .ToListAsync();

            return new OrdersPaginatedViewModel
            {
                Orders = orders,
                CurrentPage = page,
                TotalPages = totalPages
            };
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
                    PhoneNumber = o.PhoneNumber
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
                PhoneNumber = order.PhoneNumber,
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

        //Get all order statuses
        public async Task<IEnumerable<OrderStatusViewModel>> GetAllOrderStatusesAsync()
        {
            var orderStatuses = await repository
                .AllAsReadOnly<OrderStatus>()
                .Select(os => new OrderStatusViewModel()
                {
                    Id = os.Id,
                    OrderStatusName = os.OrderStatusName
                })
                .ToListAsync();

            return orderStatuses;
        }

        //Get order with it's status as viewModel
        public async Task<OrderEditStatusViewModel> GetOrderForStatusEditingAsync(int orderId)
        {
            var order = await repository
                .AllAsReadOnly<Order>()
                .Include(o => o.OrderStatus)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            return new OrderEditStatusViewModel
            {
                OrderId = order.Id,
                CurrentStatus = order.OrderStatus.OrderStatusName,
                OrderStatuses = await GetAllOrderStatusesAsync()
            };
        }

        //Edit status of an order
        public async Task<bool> EditStatusAsync(int orderId, int newStatusId)
        {
            var order = await repository
                .All<Order>()
                .FirstOrDefaultAsync(o => o.Id == orderId);

            var status = await repository
                .AllAsReadOnly<OrderStatus>()
                .AnyAsync(s => s.Id == newStatusId);

            if (order == null || !status)
            {
                return false;
            }

            order.OrderStatusId = newStatusId;
            await repository.SaveChangesAsync();
            return true;
        }

        //-----------------------------------------------------------------------------------------USER SERVICES:
        //Get all users WITH roles (for visual improvement in the All.cshtml)
        public async Task<IEnumerable<UserAllViewModel>> GetAllUsersAsync()
        {
            var allUsers = await userManager
                .Users
                .OrderBy(u => u.UserName)
                .ToListAsync();

            var userList = new List<UserAllViewModel>();

            foreach (var user in allUsers)
            {
                var roles = await userManager.GetRolesAsync(user);

                userList.Add(new UserAllViewModel
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    IsAdmin = roles.Contains(AdminRole)
                });
            }
            return userList;
        }

        //Get details of user
        public async Task<UserDetailsViewModel> GetUserDetailsAsync(string userId)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var roles = await userManager.GetRolesAsync(user);

            var model = new UserDetailsViewModel
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Roles = roles.ToList()
            };

            return model;
        }

        //Get user by Id (tracking)
        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            var user = await repository
                .All<ApplicationUser>()
                .FirstOrDefaultAsync(u => u.Id == userId);

            return user;
        }

        //-----------------------------------------------------------------------------------------PRODUCT SERVICES:

        //Add new product
        public async Task<int> AddProductAsync(ProductAddViewModel model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                FullDescription = model.FullDescription,
                DateAdded = DateTime.UtcNow,
                FlowersCount = model.FlowersCount,
                Availability = model.FlowersCount > 0,
                CategoryId = model.CategoryId
            };

            await repository.AddAsync(product);
            await repository.SaveChangesAsync();
            return product.Id;
        }

        //Get edit form of product
        public async Task<ProductEditViewModel> GetEditProductAsync(int productId)
        {
            var product = await repository
                .AllAsReadOnly<Product>()
                .FirstOrDefaultAsync(p => p.Id == productId);

            var model = new ProductEditViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                FullDescription = product.FullDescription,
                DateAdded = product.DateAdded,
                FlowersCount = product.FlowersCount,
                Availability = product.Availability,
                CategoryId = product.CategoryId
            };

            model.Categories = await productService.GetAllCategoriesAsync();
            return model;
        }

        //Post edit form of product
        public async Task<ProductEditViewModel> PostEditProductAsync(ProductEditViewModel model)
        {
            var product = await repository
                .All<Product>()
                .FirstOrDefaultAsync(p => p.Id == model.Id);

            product.Name = model.Name;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;
            product.FullDescription = model.FullDescription;
            product.DateAdded = model.DateAdded;
            product.FlowersCount = model.FlowersCount;
            product.Availability = model.FlowersCount > 0;
            product.CategoryId = model.CategoryId;

            await repository.SaveChangesAsync();
            return model;
        }

        //Delete product
        public async Task<ProductDeleteViewModel> DeleteProductAsync(int productId)
        {
            var product = await repository
                .AllAsReadOnly<Product>()
                .Where(p => p.Id == productId)
                .FirstOrDefaultAsync();

            var model = new ProductDeleteViewModel()
            {
                Id = product.Id,
                Name = product.Name
            };

            return model;
        }

        //Confirm delete
        public async Task<int> ConfirmDeleteAsync(int productId)
        {
            var product = await repository
                .All<Product>()
                .Where(p => p.Id == productId)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                throw new InvalidOperationException("Not found");
            }

            await repository.RemoveAsync(product);
            await repository.SaveChangesAsync();
            return product.Id;
        }

        //Get all low stock products that are at or below 3 as quantity
        public async Task<IEnumerable<ProductAllLowStockViewModel>> GetLowStockProductsAsync(int threshold = 3)
        {
            return await repository
                .AllAsReadOnly<Product>()
                .Where(p => p.FlowersCount <= threshold)
                .Select(p => new ProductAllLowStockViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    FlowersCount = p.FlowersCount
                })
                .ToListAsync();
        }
    }
}
