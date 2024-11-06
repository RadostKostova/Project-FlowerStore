using FlowerStore.Infrastructure.Data.Models.Roles;

namespace FlowerStore.Core.Contracts
{
    /// <summary>
    /// Interface for User services
    /// </summary>
   
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser?> GetUserByIdAsync(string userId);
        Task<bool> ExistByEmailAsync(string email);
    }
}
