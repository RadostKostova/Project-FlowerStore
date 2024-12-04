using FlowerStore.Infrastructure.Data.Models.Roles;

namespace FlowerStore.Core.Contracts
{
    /// <summary>
    /// Interface for User services
    /// </summary>
   
    public interface IUserService
    {
        Task UpdateUserInfoAsync(string userId);
    }
}
