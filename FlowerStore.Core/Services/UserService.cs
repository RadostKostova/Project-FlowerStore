using FlowerStore.Core.Contracts;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using FlowerStore.Infrastructure.Data.Models.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Core.Services
{
    /// <summary>
    /// User service for user managment
    /// </summary>
    
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(IRepository _repository,
            UserManager<ApplicationUser> _userManager)
        {
            repository = _repository;
            userManager = _userManager;
        }

        //Get all users
        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await repository
                .AllAsReadOnly<ApplicationUser>() //should be ViewModel
                .ToListAsync();
        }

        //Get user by id
        public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
        {
            return await repository
                .AllAsReadOnly<ApplicationUser>()
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        //Check if user exist by email, return boolean
        public async Task<bool> ExistByEmailAsync(string email)
        {
            return await repository
                .AllAsReadOnly<ApplicationUser>()
                .AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }

        //Get user's first, last name and phone from the last order that the user placed and save to AspNetUsers
        public async Task UpdateUserInfoAsync(string userId)
        {
            var user = await repository
                .All<ApplicationUser>()
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) return;

            var order = await repository
                .AllAsReadOnly<Order>()
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefaultAsync();

            if (order == null) return;

            user.FirstName = order.FirstName;
            user.LastName = order.LastName;
            user.PhoneNumber = order.PhoneNumber;

            await repository.SaveChangesAsync();
        }
    }
}
