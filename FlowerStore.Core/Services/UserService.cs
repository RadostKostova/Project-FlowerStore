using FlowerStore.Core.Contracts;
using FlowerStore.Infrastructure.Common;
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



        //public async Task UpdateUserInfoAsync(string userId, UserEditViewModel model)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    if (user == null) return;

        //    user.FirstName = model.FirstName;
        //    user.LastName = model.LastName;
        //    user.Phone = model.Phone;

        //    await userManager.UpdateAsync(user);
        //}
    }
}
